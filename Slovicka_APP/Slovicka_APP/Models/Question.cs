using System;
using System.Collections.Generic;
using System.Text;

namespace Slovicka_APP.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }

        List<Translate> Usages = new List<Translate>();
        int used = 0;

        public Question GetNewQuestion(List<Translate> gameList, bool translate)
        {
            Random r = new Random();
            var posts = gameList;

            if (Usages.Count == gameList.Count)
            {
                used = 0;
                Usages.Clear();
            }

            if (used > 0)
            {
                while (true)
                {
                    bool b = false;
                    int i = r.Next(0, posts.Count);
                    var quest = posts[i];

                    foreach (var item in Usages)
                    {
                        if (item.FirstWord == quest.FirstWord)
                        {
                            b = true; break;
                        }
                    }

                    if (b == false)
                    {
                        Question question = new Question();

                        if (translate == false)
                        {
                            question.QuestionText = quest.FirstWord;
                            question.CorrectAnswer = quest.SecondWord;
                        }
                        else
                        {
                            question.QuestionText = quest.SecondWord;
                            question.CorrectAnswer = quest.FirstWord;
                        }

                        Usages.Add(quest);
                        used++;
                        return question;
                    }
                }
            }
            else
            {
                Question question = new Question();
                int i = r.Next(0, posts.Count);
                var quest = posts[i];

                if (translate == false)
                {
                    question.QuestionText = quest.FirstWord;
                    question.CorrectAnswer = quest.SecondWord;
                }
                else
                {
                    question.QuestionText = quest.SecondWord;
                    question.CorrectAnswer = quest.FirstWord;
                }
                Usages.Add(quest);
                used++;
                return question;
            }
        }
    }
}
