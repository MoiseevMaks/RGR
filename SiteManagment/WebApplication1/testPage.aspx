<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="testPage.aspx.cs" Inherits="WebApplication1.testPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var timeLeft = parseInt('<%= RemainingTime.TotalSeconds %>'); // Оставшееся время в секундах

        function countdown() {
            if (timeLeft <= 0) {
                finishTest();
            } else {
                var minutes = Math.floor(timeLeft / 60);
                var seconds = timeLeft % 60;
                document.getElementById('timer').innerHTML = minutes.toString().padStart(2, '0') + ":" + seconds.toString().padStart(2, '0');
                timeLeft--;
                setTimeout(countdown, 1000);
            }
        }

        function finishTest() {
            document.getElementById('timer').innerHTML = "Время вышло!";
            document.getElementById('<%= btnFinish.ClientID %>').click(); // Автоматическое нажатие кнопки завершения теста
        }

        countdown(); // Запуск таймера при загрузке страницы
    </script>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Тест</h1>

    <div>
        <asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:RadioButtonList ID="rbAnswers" runat="server"></asp:RadioButtonList>
    </div>

    <div>
        <asp:Button ID="btnNext" runat="server" Text="Следующий вопрос" OnClick="btnNext_Click" Visible="false" />
        <asp:Button ID="btnFinish" runat="server" Text="Завершить тест" OnClick="btnFinish_Click" Visible="false" />
    </div>

    <div>
        <p>Оставшееся время: <span id="timer"></span></p>
    </div>
     <asp:HiddenField ID="hdnRemainingTime" runat="server" Value="<%= RemainingTime.TotalSeconds %>"></asp:HiddenField>
</asp:Content>
