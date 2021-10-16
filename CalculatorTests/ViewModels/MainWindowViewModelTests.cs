using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Core.Calculators;
using Moq;

namespace Calculator.ViewModels.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {
        private MainWindowViewModel _viewModel;
        private Mock<ICalculator> _calculatorMock;

        [TestInitialize]
        public void Init()
        {
            _calculatorMock = new Mock<ICalculator>();
            _viewModel = new MainWindowViewModel(_calculatorMock.Object);
        }


        [TestMethod()]
        public void ClearCommand_ShouldClearExpression()
        {
            _viewModel.Expression = "3+5";

            _viewModel.ClearCommand.Execute(null);

            Assert.IsTrue(string.IsNullOrWhiteSpace(_viewModel.Expression));
        }

        [TestMethod]
        public void EqualsCommand_ShouldCalculateExpression()
        {
            _viewModel.Expression = "3+5";
            _calculatorMock.Setup(x => x.Calculate("3+5")).Returns(8);

            _viewModel.EqualsCommand.Execute(null);

            Assert.AreEqual(_viewModel.Expression, "8");
        }

        [TestMethod]
        public void ButtonPushedCommand_ShouldAppendValueToExpressiont()
        {
            _viewModel.Expression = "3+5";

            _viewModel.ButtonPushedCommand.Execute("+");

            Assert.AreEqual("3+5+", _viewModel.Expression);
        }

        [TestMethod]
        public void ClearCommand_ShouldCallEqualsCommandRaseCanExecuteChanged()
        {
            var fired = false;
            _viewModel.EqualsCommand.CanExecuteChanged += (s, e) => fired = true;

            _viewModel.ClearCommand.Execute(null);

            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ButtonPushedCommand_ShouldCallEqualsCommandRaiseCanExecuteChanged()
        {
            var fired = false;
            _viewModel.EqualsCommand.CanExecuteChanged += (s, e) => fired = true;

            _viewModel.ButtonPushedCommand.Execute("8");

            Assert.IsTrue(fired);
        }
    }
}