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

            // 텍스트박스 읽기 전용 및 색상 지정
            txt_Cause.ReadOnly = true;
            txt_Result.ReadOnly = true;

            txt_Cause.BackColor = Color.White;
            txt_Result.BackColor = Color.White;
            
            txt_Cause.TabStop = false;
            txt_Result.TabStop = false;

            // ===== 포커스 숨기기 (커서, 드래그 방지) =====
            txt_Cause.Enter += TextBox_Enter;
            txt_Result.Enter += TextBox_Enter;
            txt_Cause.GotFocus += TextBox_Enter;
            txt_Result.GotFocus += TextBox_Enter;

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

            // === 괄호 버튼 이벤트 연결 추가 ===
            btn_Parenthesis1.Click += btn_Parenthesis1_Click; // '(' 버튼
            btn_Parenthesis2.Click += btn_Parenthesis1_Click; // ')' 버튼

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

            // 키보드 입력을 최우선으로 가로채기 활성화
            this.KeyPreview = true;
            this.KeyDown += Calculator_KeyDown;
            
            // 폼 아무 곳이나 클릭해도 포커스를 폼 자체로 유지
            this.Click += TextBox_Enter;
        }

        // ===== 텍스트박스 포커스 방지 이벤트 =====
        private void TextBox_Enter(object? sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }

        // ===== Enter 키 등 특수키 가로채기 최우선 방어막 =====
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // 조합키 필터링 (순수 누름 감별)
            Keys baseKey = keyData & Keys.KeyCode;
            
            if (baseKey == Keys.Enter)
            {
                btn_InputEquals.PerformClick();
                return true; 
            }
            else if (baseKey == Keys.Back)
            {
                btn_Del.PerformClick();
                return true;
            }
            else if (baseKey == Keys.Escape)
            {
                btn_C.PerformClick();
                return true;
            }
            else if (baseKey == Keys.Delete)
            {
                btn_CE.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // 키보드 입력 가로채기 (위에서 해결 안된 나머지 키들)
        private void Calculator_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
                    btn_Plus.PerformClick();
                else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.Multiply)
                    btn_Multiplication.PerformClick();
                // 🌟 추가된 부분: 키보드로 괄호 (, ) 입력 처리
                else if (e.KeyCode == Keys.D9)
                    btn_Parenthesis1.PerformClick(); // '(' 버튼 (Shift + 9)
                else if (e.KeyCode == Keys.D0)
                    btn_Parenthesis2.PerformClick(); // ')' 버튼 (Shift + 0)
                
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.D0: case Keys.NumPad0: btn_Input0.PerformClick(); break;
                case Keys.D1: case Keys.NumPad1: btn_Input1.PerformClick(); break;
                case Keys.D2: case Keys.NumPad2: btn_Input2.PerformClick(); break;
                case Keys.D3: case Keys.NumPad3: btn_Input3.PerformClick(); break;
                case Keys.D4: case Keys.NumPad4: btn_Input4.PerformClick(); break;
                case Keys.D5: case Keys.NumPad5: btn_Input5.PerformClick(); break;
                case Keys.D6: case Keys.NumPad6: btn_Input6.PerformClick(); break;
                case Keys.D7: case Keys.NumPad7: btn_Input7.PerformClick(); break;
                case Keys.D8: case Keys.NumPad8: btn_Input8.PerformClick(); break;
                case Keys.D9: case Keys.NumPad9: btn_Input9.PerformClick(); break;
                case Keys.Add: case Keys.Oemplus: btn_Plus.PerformClick(); break; 
                case Keys.Subtract: case Keys.OemMinus: btn_Minus.PerformClick(); break; 
                case Keys.Multiply: btn_Multiplication.PerformClick(); break; 
                case Keys.Divide: case Keys.OemQuestion: btn_Division.PerformClick(); break;
                case Keys.Decimal: case Keys.OemPeriod: 
                    button3_Click(this, EventArgs.Empty);
                    break;
            }
            
            // 키보드 기본 비프음 등 차단
            e.Handled = true;
            e.SuppressKeyPress = true;
            
            // 포커스 무조건 폼으로 돌려놓기 (어디선가 훔쳐갔을 경우 대비)
            this.ActiveControl = null;
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
                txt_Result.Text = "0."; // '0>' 를 '0.' 으로 수정
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

                // 기호 이전에 아무 숫자도 없다면 0부터 시작하도록 처리
                if (_isNewEntry && string.IsNullOrEmpty(txt_Cause.Text))
                {
                    txt_Cause.Text = txt_Result.Text;
                }

                string op = btn.Text;

                // 이미 연산자가 입력된 상태에서 다른 연산자를 눌렀을 때 기호 덮어쓰기
                if (_isNewEntry && txt_Cause.Text.Length >= 3 && 
                    (txt_Cause.Text.EndsWith(" + ") || txt_Cause.Text.EndsWith(" - ") || 
                     txt_Cause.Text.EndsWith(" X ") || txt_Cause.Text.EndsWith(" * ") || 
                     txt_Cause.Text.EndsWith(" ÷ ") || txt_Cause.Text.EndsWith(" / ")))
                {
                    txt_Cause.Text = txt_Cause.Text.Substring(0, txt_Cause.Text.Length - 3) + $" {op} ";
                }
                else
                {
                    txt_Cause.Text += $" {op} ";
                }

                _currentOperator = op;
                _isNewEntry = true;
                
                // 주의: 연산자 간 우선순위 처리를 위해 여기서 곧바로 계산하지 않고 식만 계속 이어 나갑니다.
            }
        }

        // 등호(=) 버튼
        private void EqualsButton_Click(object? sender, EventArgs e)
        {
            // 수식이 아예 비어있거나 "0"인 경우에만 계산 무시
            if (string.IsNullOrWhiteSpace(txt_Cause.Text) || txt_Cause.Text == "0") return;

            try
            {
                string expression = txt_Cause.Text;

                // 1. 계산 가능한 기호로 변환 (X -> *, ÷ -> /)
                string computeExpr = expression.Replace("X", "*").Replace("÷", "/");

                // 🌟 추가된 부분: 생략된 곱셈 기호 추가 (숫자와 괄호, 괄호와 숫자, 괄호와 괄호 사이)
                computeExpr = System.Text.RegularExpressions.Regex.Replace(computeExpr, @"(\d)\s*\(", "$1 * (");
                computeExpr = System.Text.RegularExpressions.Regex.Replace(computeExpr, @"\)\s*(\d)", ") * $1");
                computeExpr = System.Text.RegularExpressions.Regex.Replace(computeExpr, @"\)\s*\(", ") * (");

                // 2. 정수 나눗셈 시 소수점을 잃어버리는 현상 방지:
                // 식에 포함된 모든 정수(예: 3)를 실수형태(예: 3.0)로 변환 (정규표현식 활용)
                computeExpr = System.Text.RegularExpressions.Regex.Replace(computeExpr, @"(?<!\.)\b\d+\b(?!\.)", "$0.0");

                // 3. 0으로 나누기 예외 처리
                if (computeExpr.Contains("/ 0.0") || computeExpr.Contains("/0.0") || computeExpr.Contains("/ 0") || computeExpr.Contains("/0"))
                {
                    ShowDivideByZeroError();
                    return;
                }

                // 4. 연산자 우선순위가 자동 적용되는 DataTable.Compute 활용
                System.Data.DataTable table = new System.Data.DataTable();
                object evaluateResult = table.Compute(computeExpr, "");
                double result = Convert.ToDouble(evaluateResult);

                // 무한대 에러 처리 방어
                if (double.IsInfinity(result) || double.IsNaN(result))
                {
                    ShowDivideByZeroError();
                    return;
                }

                txt_Result.Text = result.ToString();
                txt_Cause.Text = $"{expression} = {result}";
                
                _firstOperand = result;
                _currentOperator = ""; 
                _isNewEntry = true;    
                _isCalculated = true;  
            }
            catch (Exception)
            {
                // 잘못된 수식이나 에러 발생 시 처리
                txt_Result.Text = "Error";
                _isNewEntry = true;
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
         
        private void button15_Click(object sender, EventArgs e) { }

        // 괄호 버튼 클릭 이벤트 핸들러
        private void btn_Parenthesis1_Click(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null)
            {
                // 방금 '='로 계산이 끝난 상태라면 화면을 초기화하고 수식을 새로 시작합니다.
                if (_isCalculated)
                {
                    txt_Cause.Text = "";
                    txt_Result.Text = "0";
                    _isCalculated = false;
                }

                // 수식 창이 0이거나 비어있을 때는 기존 0을 지우고 괄호를 넣습니다.
                if (txt_Cause.Text == "0" || string.IsNullOrEmpty(txt_Cause.Text))
                {
                    txt_Cause.Text = btn.Text;
                }
                else
                {
                    txt_Cause.Text += btn.Text;
                }

                _isNewEntry = true;
            }
        }
    }
}
