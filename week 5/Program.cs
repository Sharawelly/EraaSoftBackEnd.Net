namespace week5
{
    public class Subject
    {
        public List<Student> Students { get; set; }
        public Instructor Instructor { get; set; }
        public List<Exam> Exams { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public Subject()
        {
            Students = new List<Student>();
            Exams = new List<Exam>();
        }

        public Subject(int subjectId, string subjectName) : this()
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            Students = new List<Student>();
            Exams = new List<Exam>();
        }

        public void AssignInstructor(Instructor instructor)
        {
            this.Instructor = instructor;
        }

        public void AssignStudent(Student student)
        {
            this.Students.Add(student);
        }

        public void AddExam(Exam exam)
        {
            this.Exams.Add(exam);
        }

        public override string ToString()
        {
            return $"{SubjectName}";
        }
    }

    public abstract class User
    {
        public List<Subject> Subjects { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public User()
        {
            Subjects = new List<Subject>();
        }

        public User(int id, string name) : this()
        {
            Id = id;
            Name = name;
            Subjects = new List<Subject>();
        }

        public void AddSubject(Subject subject)
        {
            this.Subjects.Add(subject);
        }
    }

    public class Student : User
    {
        public Student(int id, string name) : base(id, name) { }

       public void NotifyStudent()
        {
            Console.WriteLine($"Notification sent to student {Name}");
        }
    }

    public class Instructor : User
    {
        public Instructor(int id, string name) : base(id, name) { }
    }

    public class Exam
    {
        public int ExamId { get; set; }
        public Subject Subject { get; set; }
        public DateTime ExamDate { get; set; }
        public int Mark { get; set; }
        public int NumberOfQuestions { get; set; }
        public string Duration { get; set; }
        public string Mode { get; set; }
        public List<Question> Questions { get; set; }

        public Exam()
        {
            Questions = new List<Question>();
        }

        public Exam(int examId, Subject subject, DateTime examDate, int mark,
                    int numberOfQuestions, string duration, string mode) : this()
        {
            ExamId = examId;
            Subject = subject;
            ExamDate = examDate;
            Mark = mark;
            NumberOfQuestions = numberOfQuestions;
            Duration = duration;
            Mode = mode;
            Questions = new List<Question>();
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public void ShowExam()
        {
            Console.WriteLine($"\n=== FINAL EXAM: {ExamId} ===");
            Console.WriteLine($"Subject: {Subject?.SubjectName}");
            Console.WriteLine($"Duration: {Duration} minutes");
            Console.WriteLine($"Total Questions: {NumberOfQuestions}");
            Console.WriteLine($"Date: {ExamDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"Location: Online");
            Console.WriteLine($"Mode: {Mode}");
            Console.WriteLine("=====================================\n");

            foreach (var question in Questions)
            {
                question.DisplayQuestion();
            }
        }

         public void StartExam()
            {
            ExamStarted?.Invoke();
        }
        public event Action ExamStarted; 



        public override string ToString()
        {
            return $"{Subject?.SubjectName} - {ExamDate.ToShortDateString()} - {Mark}/{NumberOfQuestions}";
        }
    }

    public abstract class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string Level { get; set; }
        public int Mark { get; set; }

        public Question() { }

        public Question(int questionId, string questionText, string level, int mark) : this()
        {
            QuestionId = questionId;
            QuestionText = questionText;
            Level = level;
            Mark = mark;
        }

        public abstract void DisplayQuestion();

        public override string ToString()
        {
            return $"{QuestionText} ({Level}) - {Mark} points";
        }
    }

    public class OneMultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public string Answer { get; set; }

        public OneMultipleChoiceQuestion()
        {
            Options = new List<string>();
        }

        public OneMultipleChoiceQuestion(int questionId, string questionText, string answer,
            string level, int mark, List<string> options) : base(questionId, questionText, level, mark)
        {
            Options = options ?? new List<string>();
            Answer = answer;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{QuestionText} ({Level}) - {Mark} points");
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }
        }
    }

    public class MultipleMultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public string Answer { get; set; }

        public MultipleMultipleChoiceQuestion()
        {
            Options = new List<string>();
        }

        public MultipleMultipleChoiceQuestion(int questionId, string questionText, string answer,
            string level, int mark, List<string> options) : base(questionId, questionText, level, mark)
        {
            Options = options ?? new List<string>();
            Answer = answer;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{QuestionText} ({Level}) - {Mark} points");
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }
        }
    }

    public class TrueFalseQuestion : Question
    {
        public bool IsTrue { get; set; }

        public TrueFalseQuestion(int questionId, string questionText, string level, int mark, bool isTrue)
            : base(questionId, questionText, level, mark)
        {
            IsTrue = isTrue;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{QuestionText} ({Level}) - {Mark} points");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Setup sample subject and instructor
            Subject subject = new Subject(1, "Computer Science");
            Instructor instructor = new Instructor(1, "Mando");
            subject.AssignInstructor(instructor);

            // Setup students
            Student s1 = new Student(101, "Marawan");
            Student s2 = new Student(102, "Morey");
            subject.AssignStudent(s1);
            subject.AssignStudent(s2);


            // Create exam
            Exam exam = new Exam(1, subject, DateTime.Now.AddDays(7), 100, 0, "90", "Online");
            subject.AddExam(exam);

            exam.ExamStarted += s1.NotifyStudent;
            exam.ExamStarted += s2.NotifyStudent;

            // ===== MENU LOOP =====
            while (true)
            {
                Console.WriteLine("\n=== Exam System Menu ===");
                Console.WriteLine("1. Login as Instructor");
                Console.WriteLine("2. Login as Student");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                if (choice == "1") // Instructor Menu
                {
                    Console.Write("Enter Instructor Name: ");
                    string name = Console.ReadLine();

                    if (name != instructor.Name)
                    {
                        Console.WriteLine("Invalid Instructor!");
                        continue;
                    }

                    Console.WriteLine("\n--- Instructor Menu ---");
                    Console.WriteLine("1. Add Question(s) to Exam");
                    Console.WriteLine("2. Show Exam");
                    Console.WriteLine("3. Start Exam");
                    Console.Write("Enter choice: ");
                    string instChoice = Console.ReadLine();

                    if (instChoice == "1")
                    {
                        Console.Write("How many questions do you want to add? ");
                        int numQ = int.Parse(Console.ReadLine());

                        for (int qn = 0; qn < numQ; qn++)
                        {
                            Console.WriteLine($"\n--- Adding Question {qn + 1} of {numQ} ---");

                            Console.Write("Enter question type (1=OneChoice, 2=MultiChoice, 3=TrueFalse): ");
                            int type = int.Parse(Console.ReadLine());

                            Console.Write("Enter Question Text: ");
                            string text = Console.ReadLine();
                            Console.Write("Enter Level (Easy/Medium/Hard): ");
                            string level = Console.ReadLine();
                            Console.Write("Enter Mark: ");
                            int mark = int.Parse(Console.ReadLine());

                            if (type == 1)
                            {
                                Console.Write("Enter Correct Answer: ");
                                string answer = Console.ReadLine();
                                List<string> options = new List<string>();
                                for (int i = 0; i < 4; i++)
                                {
                                    Console.Write($"Option {i + 1}: ");
                                    options.Add(Console.ReadLine());
                                }
                                var q = new OneMultipleChoiceQuestion(exam.Questions.Count + 1, text, answer, level, mark, options);
                                exam.AddQuestion(q);
                            }
                            else if (type == 2)
                            {
                                Console.Write("Enter Correct Answers (comma separated): ");
                                string answer = Console.ReadLine();
                                List<string> options = new List<string>();
                                for (int i = 0; i < 4; i++)
                                {
                                    Console.Write($"Option {i + 1}: ");
                                    options.Add(Console.ReadLine());
                                }
                                var q = new MultipleMultipleChoiceQuestion(exam.Questions.Count + 1, text, answer, level, mark, options);
                                exam.AddQuestion(q);
                            }
                            else if (type == 3)
                            {
                                Console.Write("Is True (y/n): ");
                                bool isTrue = Console.ReadLine().ToLower() == "y";
                                var q = new TrueFalseQuestion(exam.Questions.Count + 1, text, level, mark, isTrue);
                                exam.AddQuestion(q);
                            }
                        }

                        // update number of questions in the exam
                        exam.NumberOfQuestions = exam.Questions.Count;

                        Console.WriteLine($"\n{numQ} question(s) added successfully!");
                    }
                    else if (instChoice == "2")
                    {
                        exam.ShowExam();
                    }
                    else if (instChoice == "3")
                    {
                        exam.StartExam();
                        Console.WriteLine("Exam started and notifications sent to students.");
                    }
                }
                else if (choice == "2") // Student Menu
                {
                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine();

                    Student student = subject.Students.Find(s => s.Name == name);
                    if (student == null)
                    {
                        Console.WriteLine("Student not found!");
                        continue;
                    }

                    Console.WriteLine("\n--- Student Menu ---");
                    Console.WriteLine("1. Take Exam");
                    Console.WriteLine("2. View Subjects");
                    Console.Write("Enter choice: ");
                    string studChoice = Console.ReadLine();

                    if (studChoice == "1")
                    {
                        if (subject.Exams.Count == 0)
                        {
                            Console.WriteLine("No exams available!");
                            continue;
                        }

                        Exam e = subject.Exams[0];
                        Console.WriteLine($"\nStarting Exam: {e.Subject.SubjectName}");
                        e.ShowExam();

                        int score = 0;
                        int correctAnswers = 0;

                        foreach (var q in e.Questions)
                        {
                            q.DisplayQuestion();
                            Console.Write("Your Answer: ");
                            string ans = Console.ReadLine();

                            if (q is OneMultipleChoiceQuestion one && ans.Equals(one.Answer, StringComparison.OrdinalIgnoreCase))
                            {
                                score += one.Mark;
                                correctAnswers++;
                            }
                            else if (q is MultipleMultipleChoiceQuestion multi && ans.Equals(multi.Answer, StringComparison.OrdinalIgnoreCase))
                            {
                                score += multi.Mark;
                                correctAnswers++;
                            }
                            else if (q is TrueFalseQuestion tf && ((ans == "1" && tf.IsTrue) || (ans == "2" && !tf.IsTrue)))
                            {
                                score += tf.Mark;
                                correctAnswers++;
                            }
                        }

                        Console.WriteLine($"\nExam finished! You answered {correctAnswers}/{e.Questions.Count} correctly.");
                        Console.WriteLine($"Final Score: {score}/{e.Mark}");
                    }
                    else if (studChoice == "2")
                    {
                        Console.WriteLine("\nEnrolled Subjects:");
                        foreach (var subj in student.Subjects)
                            Console.WriteLine(subj.SubjectName);
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }

    }
}
