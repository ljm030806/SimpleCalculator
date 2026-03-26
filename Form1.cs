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

            // 모든 사칙연산 버튼 이벤트를 연결합니다.
            btn_Plus.Click += OperatorButton_Click;
            btn_Minus.Click += OperatorButton_Click;
            btn_Multiplication.Click += OperatorButton_Click;
            btn_Division.Click += OperatorButton_Click;

            // 결과(=) 버튼 연결 (초기화 버튼 연결 부분 삭제됨)
            btn_InputEquals.Click += EqualsButton_Click;
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

                txt_Cause.Text += btn.Text;

                if (_isNewEntry)
                {
                    txt_Result.Text = btn.Text;
                    _isNewEntry = false;
                }
                else
                {
                    if (txt_Result.Text == "0")
                        txt_Result.Text = btn.Text;
                    else
                        txt_Result.Text += btn.Text;
                }
            }
        }

        // 사칙연산 버튼 클릭 이벤트 핸들러
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

                txt_Cause.Text += btn.Text;

                // 연속으로 연산기호를 누르는 경우 이전 기호에 맞춰 중간 계산을 수행합니다.
                if (!_isNewEntry && _currentOperator != "")
                {
                    double.TryParse(txt_Result.Text, out double tempOperand);
                    switch (_currentOperator)
                    {
                        case "+": _firstOperand += tempOperand; break;
                        case "-": _firstOperand -= tempOperand; break;
                        case "X": case "*": _firstOperand *= tempOperand; break;
                        case "÷": case "/": 
                            // 0으로 나눗셈 방지 처리 제거됨
                            _firstOperand /= tempOperand;
                            break;
                    }
                    txt_Result.Text = _firstOperand.ToString();
                }
                else
                {
                    // 첫 기호 입력인 경우
                    double.TryParse(txt_Result.Text, out _firstOperand);
                }

                // 버튼에 적힌 글자(+, -, X, ÷)를 새로운 연산자로 등록
                _currentOperator = btn.Text;
                _isNewEntry = true;
            }
        }

        // 등호(=) 버튼 클릭 이벤트 핸들러
        private void EqualsButton_Click(object? sender, EventArgs e)
        {
            if (_currentOperator == "") return;

            if (double.TryParse(txt_Result.Text, out double secondOperand))
            {
                double result = 0;

                // 모든 사칙연산 기호에 대한 계산 처리를 수행합니다.
                switch (_currentOperator)
                {
                    case "+":
                        result = _firstOperand + secondOperand;
                        break;
                    case "-":
                        result = _firstOperand - secondOperand;
                        break;
                    case "X":
                    case "*":
                        result = _firstOperand * secondOperand;
                        break;
                    case "÷":
                    case "/":
                        // 0으로 나눗셈 에러 창 띄우는 로직 제거됨
                        result = _firstOperand / secondOperand;
                        break;
                }

                txt_Result.Text = result.ToString();
                txt_Cause.Text += "=" + result.ToString();
                
                _firstOperand = result;
                _currentOperator = ""; 
                _isNewEntry = true;    
                _isCalculated = true;  
            }
        }

        // 소수점 버튼 이벤트 핸들러 - 임시 비활성화
        private void button3_Click(object sender, EventArgs e)
        {
            // 기능 보류: 아무 동작도 하지 않음
        }

        private void button15_Click(object sender, EventArgs e)
        {
        }
    }
}
