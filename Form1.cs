using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Calculator : Form
    {
        // 계산 상태를 저장할 변수들
        private double _firstOperand = 0;     // 첫 번째 입력된 숫자
        private string _currentOperator = ""; // 현재 선택된 연산자
        private bool _isNewEntry = true;      // 새롭게 숫자를 입력해야 하는지 여부
        private bool _isCalculated = false;   // '=' 을 눌러 계산이 완료된 직후인지 여부
        
        // Timer 클래스 충돌 방지를 위해 명시적 네임스페이스 사용
        private System.Windows.Forms.Timer _errorResetTimer;

        public Calculator()
        {
            InitializeComponent();

            // 텍스트박스 읽기 전용 및 색상 지정 (커서/클릭 방지)
            txt_Cause.ReadOnly = true;
            txt_Result.ReadOnly = true;

            txt_Cause.BackColor = Color.White;
            txt_Result.BackColor = Color.White;
            
            txt_Cause.TabStop = false;
            txt_Result.TabStop = false;

            // 숫자 버튼 이벤트 일괄 연결
            btn_Input0.Click += NumberButton_Click;
            btn_Input1.Click += NumberButton_Click;
            btn_Input2.Click += NumberButton_Click;
            btn_Input3.Click += NumberButton_Click;
            btn_Input4.Click += NumberButton_Click;
            btn_Input5.Click += NumberButton_Click;
            btn_Input6.Click += NumberButton_Click;
            btn_Input7.Click += NumberButton_Click;
            btn_Input8.Click += NumberButton_Click;
            btn_Input9.Click += NumberButton_Click;

            // 추가 기능 버튼 이벤트
            btn_ChangeSign.Click += btn_ChangeSign_Click; // 1번: +/- 부호 변경

            // 사칙연산 버튼 이벤트 연결
            btn_Plus.Click += OperatorButton_Click;
            btn_Minus.Click += OperatorButton_Click;
            btn_Multiplication.Click += OperatorButton_Click;
            btn_Division.Click += OperatorButton_Click;

            // 결과(=) 및 삭제 관련 버튼 연결
            btn_InputEquals.Click += EqualsButton_Click;
            btn_C.Click += ClearButton_Click;
            btn_CE.Click += ClearEntryButton_Click;
            btn_Del.Click += DeleteButton_Click;
            
            // Timer 명시적 생성
            _errorResetTimer = new System.Windows.Forms.Timer();
            _errorResetTimer.Interval = 1000;
            _errorResetTimer.Tick += ErrorResetTimer_Tick;
        }

        // 공통 숫자 버튼 클릭 이벤트 핸들러
        private void NumberButton_Click(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null)
            {
                if (_isCalculated)
                {
                    txt_Cause.Text = "";
                    txt_Result.Text = "0";
                    _isCalculated = false;
                }

                if (_isNewEntry)
                {
                    txt_Result.Text = btn.Text;
                    
                    if (txt_Cause.Text == "0") 
                        txt_Cause.Text = btn.Text;
                    else
                        txt_Cause.Text += btn.Text;
                    
                    _isNewEntry = false;
                }
                else
                {
                    if (txt_Result.Text == "0")
                    {
                        txt_Result.Text = btn.Text;
                        
                        if (txt_Cause.Text.EndsWith("0"))
                        {
                            txt_Cause.Text = txt_Cause.Text.Substring(0, txt_Cause.Text.Length - 1) + btn.Text;
                        }
                    }
                    else
                    {
                        txt_Result.Text += btn.Text;
                        txt_Cause.Text += btn.Text;
                    }
                }
            }
        }

        // 1번 기능: 양수/음수 전환 기능 (+/-)
        private void btn_ChangeSign_Click(object? sender, EventArgs e)
        {
            if (txt_Result.Text == "0" || _isNewEntry) return;

            if (txt_Result.Text.StartsWith("-"))
            {
                // 음수 -> 양수
                txt_Result.Text = txt_Result.Text.Substring(1);
                
                // txt_Cause에서도 마지막 숫자의 '-' 부호 제거 로직
                int lastMinusIdx = txt_Cause.Text.LastIndexOf('-');
                if (lastMinusIdx >= 0)
                {
                    txt_Cause.Text = txt_Cause.Text.Remove(lastMinusIdx, 1);
                }
            }
            else
            {
                // 양수 -> 음수
                txt_Result.Text = "-" + txt_Result.Text;
                
                // txt_Cause의 마지막 입력된 숫자 위치 앞에 '-' 붙이기
                int insertPos = txt_Cause.Text.Length - txt_Result.Text.Length + 1;
                if (insertPos >= 0)
                {
                    txt_Cause.Text = txt_Cause.Text.Insert(insertPos, "-");
                }
            }
        }

        // 2번 기능: 소수점 버튼 내 소수점 2개 이상 방지
        private void button3_Click(object sender, EventArgs e)
        {
            if (_isCalculated)
            {
                txt_Cause.Text = "0.";
                txt_Result.Text = "0.";
                _isCalculated = false;
                _isNewEntry = false;
                return;
            }

            if (_isNewEntry)
            {
                txt_Cause.Text += "0.";
                txt_Result.Text = "0.";
                _isNewEntry = false;
                return;
            }

            // 현재 표시된 숫자에 소수점이 없는 경우에만 추가
            if (!txt_Result.Text.Contains("."))
            {
                txt_Cause.Text += ".";
                txt_Result.Text += ".";
            }
        }

        // 사칙연산 버튼 클릭 이벤트
        private void OperatorButton_Click(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null)
            {
                if (_isCalculated)
                {
                    txt_Cause.Text = txt_Result.Text;
                    _isCalculated = false;
                }

                txt_Cause.Text += $" {btn.Text} ";

                if (!_isNewEntry && _currentOperator != "")
                {
                    double.TryParse(txt_Result.Text, out double tempOperand);
                    switch (_currentOperator)
                    {
                        case "+": _firstOperand += tempOperand; break;
                        case "-": _firstOperand -= tempOperand; break;
                        case "X": case "*": _firstOperand *= tempOperand; break;
                        case "÷": case "/": 
                            // 4번: 여기서도 0으로 나누려 하면 잠시 후 진행
                            if (tempOperand == 0) 
                            {
                                ShowDivideByZeroError();
                                return;
                            }
                            _firstOperand /= tempOperand;
                            break;
                    }
                    txt_Result.Text = _firstOperand.ToString();
                }
                else
                {
                    double.TryParse(txt_Result.Text, out _firstOperand);
                }

                _currentOperator = btn.Text;
                _isNewEntry = true;
            }
        }

        // 등호(=) 버튼
        private void EqualsButton_Click(object? sender, EventArgs e)
        {
            if (_currentOperator == "") return;

            if (double.TryParse(txt_Result.Text, out double secondOperand))
            {
                double result = 0;

                switch (_currentOperator)
                {
                    case "+": result = _firstOperand + secondOperand; break;
                    case "-": result = _firstOperand - secondOperand; break;
                    case "X":
                    case "*": result = _firstOperand * secondOperand; break;
                    case "÷":
                    case "/":
                        // 4번: 0으로 나누기 방지 & 에러 텍스트 & 버튼 잠금 처리
                        if (secondOperand == 0)
                        {
                            ShowDivideByZeroError();
                            return;
                        }
                        result = _firstOperand / secondOperand;
                        break;
                }

                txt_Result.Text = result.ToString();
                txt_Cause.Text += $" = {result}";
                
                _firstOperand = result;
                _currentOperator = ""; 
                _isNewEntry = true;    
                _isCalculated = true;  
            }
        }

        // 4번: 0으로 나누기 에러 처리 (텍스트 표시 및 1초간 폼 잠금)
        private void ShowDivideByZeroError()
        {
            txt_Result.Text = "0으로 나눌 수 없습니다.";
            ToggleCalculatorState(false); // 폼 내 모든 컨트롤 비활성화 (잠금)
            _errorResetTimer.Start();      // 1초 타이머 동작 시작
        }

        // 1초 후 타이머가 발동될 때 호출 (잠금 해제 및 상태 리셋)
        private void ErrorResetTimer_Tick(object? sender, EventArgs e)
        {
            _errorResetTimer.Stop();        // 반복 방지
            ToggleCalculatorState(true);    // 버튼 잠금 해제

            // 값 초기화 (사용자 편의상 C 버튼을 누른 것과 동일하게 처리)
            btn_C.PerformClick();
        }

        // 부모(Form) 화면의 컨트롤 상태 변경 도우미 메서드
        private void ToggleCalculatorState(bool isEnabled)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    control.Enabled = isEnabled;
                }
            }
        }

        // C (Clear) 전체 초기화
        private void ClearButton_Click(object? sender, EventArgs e)
        {
            txt_Result.Text = "0";
            txt_Cause.Text = ""; 
            _firstOperand = 0;
            _currentOperator = "";
            _isNewEntry = true;
            _isCalculated = false;
        }

        // CE (Clear Entry)
        private void ClearEntryButton_Click(object? sender, EventArgs e)
        {
            if (txt_Cause.Text.EndsWith(txt_Result.Text))
            {
                txt_Cause.Text = txt_Cause.Text.Substring(0, txt_Cause.Text.Length - txt_Result.Text.Length);
            }
            
            txt_Result.Text = "0";
            _isNewEntry = true;
        }

        // Del (백스페이스)
        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            if (_isCalculated) return;

            if (txt_Result.Text.Length > 0)
            {
                txt_Result.Text = txt_Result.Text.Remove(txt_Result.Text.Length - 1);
                
                if (txt_Cause.Text.Length > 0)
                {
                    try { txt_Cause.Text = txt_Cause.Text.Remove(txt_Cause.Text.Length - 1); }
                    catch { }
                }
            }
            
            if (txt_Result.Text == "" || txt_Result.Text == "-")
            {
                txt_Result.Text = "0";
                _isNewEntry = true;
            }
        }
         
        private void button15_Click(object sender, EventArgs e)
        {
        }
    }
}
