using System;
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

        public Calculator()
        {
            InitializeComponent();

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

            // 덧셈 기호 버튼 이벤트 연결
            btn_Plus.Click += OperatorButton_Click;

            // 결과(=) 및 초기화(C) 버튼 연결
            btn_InputEquals.Click += EqualsButton_Click;
            btn_C.Click += ClearButton_Click;
        }

        // 공통 숫자 버튼 클릭 이벤트 핸들러
        private void NumberButton_Click(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null)
            {
                // 계산이 끝난 직후(=)에 새 숫자를 누르면 모든 기록 초기화 후 시작
                if (_isCalculated)
                {
                    txt_Cause.Text = "";
                    txt_Result.Text = "0";
                    _isCalculated = false;
                }

                // 내가 누른 숫자들 내역에 그대로 표시
                txt_Cause.Text += btn.Text;

                // 연산기호를 누른 직후이거나 초기 상태(_isNewEntry 가 true일 때)
                if (_isNewEntry)
                {
                    txt_Result.Text = btn.Text;
                    _isNewEntry = false;
                }
                else
                {
                    // 0만 있는 상태에서 다른 숫자를 누르면 덮어쓰기
                    if (txt_Result.Text == "0")
                        txt_Result.Text = btn.Text;
                    else
                        txt_Result.Text += btn.Text;
                }
            }
        }

        // 연산(+) 버튼 클릭 이벤트 핸들러
        private void OperatorButton_Click(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null)
            {
                // 계산이 완료된 직후(결과값이 나온 상태)에서 연산자를 누르면 내역 이어가기
                if (_isCalculated)
                {
                    txt_Cause.Text = txt_Result.Text;
                    _isCalculated = false;
                }

                // 누른 기호를 내역에 표시
                txt_Cause.Text += btn.Text;

                // 이미 덧셈 기호가 선택되어 있는데 다시 누르는 경우 (임시 계산)
                if (!_isNewEntry && _currentOperator != "")
                {
                    // 내부적으로 계산만 먼저 수행
                    double.TryParse(txt_Result.Text, out double tempOperand);
                    _firstOperand = _firstOperand + tempOperand;
                    txt_Result.Text = _firstOperand.ToString();
                }
                else
                {
                    // 첫 기호 입력인 경우 현재 값을 피연산자로 저장
                    double.TryParse(txt_Result.Text, out _firstOperand);
                }

                _currentOperator = btn.Text;
                _isNewEntry = true; // 다음은 새로운 숫자를 입력받을 준비
            }
        }

        // 등호(=) 버튼 클릭 이벤트 핸들러
        private void EqualsButton_Click(object? sender, EventArgs e)
        {
            if (_currentOperator == "") return;

            // 현재 텍스트박스의 값을 두 번째 피연산자로 가져옴
            if (double.TryParse(txt_Result.Text, out double secondOperand))
            {
                double result = 0;

                // 덧셈 기호에 따라 계산
                switch (_currentOperator)
                {
                    case "+":
                        result = _firstOperand + secondOperand;
                        break;
                }

                // 결과를 텍스트박스에 출력
                txt_Result.Text = result.ToString();
                
                // 내역에도 = 기호와 함께 결과값 표시 (예: "1+2=3")
                txt_Cause.Text += "=" + result.ToString();
                
                // 연속된 연산을 위해 현재 결과를 _firstOperand에 저장
                _firstOperand = result;
                _currentOperator = ""; // 연산 종료
                _isNewEntry = true;    // 다음 값은 새로 입력받음
                _isCalculated = true;  // 계산 완료 상태로 설정! (다음에 숫자를 누르면 리셋됨)
            }
        }

        // 초기화(C) 버튼 클릭 이벤트 핸들러
        private void ClearButton_Click(object? sender, EventArgs e)
        {
            txt_Result.Text = "0";
            txt_Cause.Text = ""; // 입력 내역 텍스트도 완전히 초기화
            _firstOperand = 0;
            _currentOperator = "";
            _isNewEntry = true;
            _isCalculated = false;
        }

        // 소수점 입력 버튼의 이벤트 핸들러 내용
        private void button3_Click(object sender, EventArgs e)
        {
            if (_isCalculated)
            {
                txt_Cause.Text = "";
                txt_Result.Text = "0";
                _isCalculated = false;
            }

            // 연산기호를 막 누른 참이면 "0." 으로 시작
            if (_isNewEntry)
            {
                txt_Cause.Text += "0.";
                txt_Result.Text = "0.";
                _isNewEntry = false;
                return;
            }

            // 이미 소수점이 찍혀 있다면 무시
            if (!txt_Result.Text.Contains("."))
            {
                txt_Cause.Text += ".";
                txt_Result.Text += ".";
            }
        }

        // 기존에 디자이너에서 더블클릭해서 생성된 이벤트 (유지 권장)
        private void button15_Click(object sender, EventArgs e)
        {
            // 사용하지 않을 경우 Form1.Designer.cs에서 이벤트 연결을 제거해야 합니다.
        }
    }
}
