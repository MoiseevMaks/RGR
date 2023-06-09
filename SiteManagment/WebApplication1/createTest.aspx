<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateTest.aspx.cs" Inherits="WebApplication1.CreateTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Создание теста</h1>
    <div>
        <asp:Label ID="TestNameLabel" runat="server" Text="Название теста:"></asp:Label>
        <asp:TextBox ID="TestNameTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="CreateTestButton" runat="server" Text="Создать тест" OnClick="CreateTestButton_Click" />
    </div>
    <hr />
    <h2>Вопросы:</h2>
    <asp:Repeater ID="QuestionsRepeater" runat="server" OnItemDataBound="QuestionsRepeater_ItemDataBound">
        <ItemTemplate>
            <div>
                <asp:HiddenField ID="QuestionIdHiddenField" runat="server" Value='<%# Eval("questionId") %>' />
                <asp:Label ID="QuestionNumberLabel" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>
                <asp:Label ID="QuestionTextLabel" runat="server" Text="Текст вопроса:"></asp:Label>
                <asp:TextBox ID="QuestionTextBox" runat="server" Text='<%# Eval("text") %>'></asp:TextBox>
                <asp:Label ID="QuestionTypeLabel" runat="server" Text="Тип вопроса:"></asp:Label>
                <asp:DropDownList ID="QuestionTypeDropDownList" runat="server">
                    <asp:ListItem Text="Одиночный выбор" Value="single"></asp:ListItem>
                    <asp:ListItem Text="Множественный выбор" Value="multiple"></asp:ListItem>
                </asp:DropDownList>
                <h4>Ответы:</h4>
                <asp:Repeater ID="AnswersRepeater" runat="server">
                    <ItemTemplate>
                        <div>
                            <asp:HiddenField ID="AnswerIdHiddenField" runat="server" Value='<%# Eval("answerId") %>' />
                            <asp:Label ID="AnswerNumberLabel" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>
                            <asp:Label ID="AnswerTextLabel" runat="server" Text="Текст ответа:"></asp:Label>
                            <asp:TextBox ID="AnswerTextBox" runat="server" Text='<%# Eval("text") %>'></asp:TextBox>
                            <asp:CheckBox ID="CorrectCheckBox" runat="server" Text="Верный ответ" Checked='<%# Eval("isCorrect") %>' />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <hr />
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Button ID="AddQuestionButton" runat="server" Text="Добавить вопрос" OnClick="AddQuestionButton_Click" />
    <br />
    <asp:Label ID="SuccessMessageLabel" runat="server" ForeColor="Green"></asp:Label>
    <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
