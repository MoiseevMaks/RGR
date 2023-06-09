using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class testPage : System.Web.UI.Page
    {
        public DateTime StartTime { get; set; }
        public TimeSpan TestDuration { get; set; }
        public TimeSpan RemainingTime => TestDuration - (DateTime.Now - StartTime);

        private List<Question> Questions { get; set; }
        private int CurrentQuestionIndex { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Установка длительности теста на 40 минут
                TestDuration = TimeSpan.FromMinutes(40);

                // Загрузка вопросов из базы данных
                Questions = LoadQuestionsFromDatabase();
                CurrentQuestionIndex = 0;

                // Начало таймера
                StartTime = DateTime.Now;

                // Загрузка первого вопроса
                LoadQuestion(CurrentQuestionIndex);

                hdnRemainingTime.Value = RemainingTime.TotalSeconds.ToString();
                // Запуск таймера
                ClientScript.RegisterStartupScript(this.GetType(), "CountdownScript", "countdown();", true);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            // Сохранение ответа на текущий вопрос
            SaveAnswer(CurrentQuestionIndex);

            // Загрузка следующего вопроса
            CurrentQuestionIndex++;
            LoadQuestion(CurrentQuestionIndex);

            // Проверка, является ли текущий вопрос последним
            if (CurrentQuestionIndex == Questions.Count - 1)
            {
                btnNext.Visible = false;
                btnFinish.Visible = true;
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            // Сохранение ответа на последний вопрос
            SaveAnswer(CurrentQuestionIndex);

            // Остановка таймера
            var elapsedDuration = DateTime.Now - StartTime;

            // Расчет процента правильных ответов
            int correctAnswers = CalculateCorrectAnswers();
            double percentage = (double)correctAnswers / Questions.Count * 100;

            // Сохранение результатов в базу данных
            SaveTestResults(elapsedDuration, percentage);

            // Перенаправление на страницу с результатами
            Response.Redirect("ResultPage.aspx");
        }

        private List<Question> LoadQuestionsFromDatabase()
        {
            int testId = Convert.ToInt32(Request.QueryString["id"]);
            List<Question> questions = new List<Question>();

            string connection = ConfigurationManager.AppSettings["connectinDB"];
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                string query = "SELECT * FROM questions WHERE testId = @testId";
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@testId", testId);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int questionId = Convert.ToInt32(reader["questionId"]);
                    string questionText = reader["text"].ToString();
                    // Загрузка вариантов ответов и других данных
                    List<Answer> answers = LoadAnswersFromDatabase(questionId);

                    // Создание объекта вопроса и добавление его в список
                    Question question = new Question(questionId, questionText);
                    question.Answers = answers;
                    questions.Add(question);
                }
                reader.Close();
            }

            return questions;
        }

        private List<Answer> LoadAnswersFromDatabase(int questionId)
        {
            List<Answer> answers = new List<Answer>();

            string connection = ConfigurationManager.AppSettings["connectinDB"];
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                string query = "SELECT * FROM answers WHERE questionId = @questionId";
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@questionId", questionId);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int answerId = Convert.ToInt32(reader["answerId"]);
                    string answerText = reader["text"].ToString();
                    bool isCorrect = Convert.ToBoolean(reader["isCorrect"]);

                    // Создание объекта ответа и добавление его в список
                    Answer answer = new Answer(answerId, answerText, isCorrect);
                    answers.Add(answer);
                }
                reader.Close();
            }

            return answers;
        }


        private void LoadQuestion(int questionIndex)
        {
            if (questionIndex < Questions.Count)
            {
                Question question = Questions[questionIndex];

                lblQuestion.Text = question.Text;
                rbAnswers.DataSource = question.Answers;
                rbAnswers.DataTextField = "Text";
                rbAnswers.DataValueField = "Id";
                rbAnswers.DataBind();

                // Загрузка выбранного ответа (если есть)
                // ...

                btnNext.Visible = true;
                btnFinish.Visible = false;
            }
        }

        private void SaveAnswer(int questionIndex)
        {
            if (questionIndex < Questions.Count)
            {
                Question question = Questions[questionIndex];
                int selectedAnswerId = Convert.ToInt32(rbAnswers.SelectedValue); // Получение выбранного значения из RadioButtonList

                // Найдите выбранный ответ в вопросе
                Answer selectedAnswer = question.Answers.FirstOrDefault(a => a.Id == selectedAnswerId);
                if (selectedAnswer != null)
                {
                    // Сохраните выбранный ответ или выполние соответствующих операций
                    // ...
                }
            }
        }

        private int CalculateCorrectAnswers()
        {
            int correctCount = 0;

            // Подсчет количества правильных ответов
            // ...

            return correctCount;
        }

        private void SaveTestResults(TimeSpan elapsedDuration, double percentage)
        {
            // Сохранение результатов теста в базу данных
            // ...
        }
        public class Question
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public List<Answer> Answers { get; set; }

            public Question(int id, string text)
            {
                Id = id;
                Text = text;
                Answers = new List<Answer>();
            }
        }
        public class Answer
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public bool IsCorrect { get; set; }

            public Answer(int id, string text, bool isCorrect)
            {
                Id = id;
                Text = text;
                IsCorrect = isCorrect;
            }
        }
        public class Test
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime CreationDate { get; set; }
            public List<Question> Questions { get; set; }
            public Test(int id, string name)
            {
                Id = id;
                Name = name;
                Questions = new List<Question>();
            }

        }
    }
}
