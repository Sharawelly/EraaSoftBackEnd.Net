namespace task_2
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Instructor : Person
    {
        public string Specialization { get; set; }

        public Instructor(int instructorId, string name, string specialization)
            : base(instructorId, name)   // pass values to base class
        {
            Specialization = specialization;
        }

       
    }


    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }

        public Instructor AssignedInstructor { get; set; }

        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            AssignedInstructor = instructor;


        }
       
    }
    public class Student : Person
    {
  
        public int Age { get; set; }
        public List<Course> EnrolledCourses { get; set; } = new List<Course>();
        public Student(int studentId, string name, int age) : base(studentId, name)
        { 
            Age = age;
        }

        public void EnrollInCourse(Course course)
        {
            EnrolledCourses.Add(course);
        }

        public bool IsEnrolledInCourse(int courseId)
        {
            return EnrolledCourses.Exists(c => c.CourseId == courseId);
        }

    }

    public class School
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public List<Course> Courses { get; set; } = new List<Course>();

        public void AddStudent(Student student) => Students.Add(student);
        public void AddInstructor(Instructor instructor) => Instructors.Add(instructor);
        public void AddCourse(Course course) => Courses.Add(course);

        public void ShowAllStudents()
        {
            Console.WriteLine("Students: :)");
            foreach (var student in Students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }
        }

        // Show all courses
        public void ShowAllCourses()
        {
            Console.WriteLine("Courses: :)");
            foreach (var course in Courses)
            {
                Console.WriteLine($"Course ID: {course.CourseId}, Title: {course.Title}, Instructor: {course.AssignedInstructor?.Name}");
            }
        }

        // Show all instructors
        public void ShowAllInstructors()
        {
            Console.WriteLine("Instructors: :)");
            foreach (var instructor in Instructors)
            {
                Console.WriteLine($"ID: {instructor.Id}, Name: {instructor.Name}, Specialization: {instructor.Specialization}");
            }
        }

        // Find student index by ID
        public int FindStudentIndex(int studentId)
        {
            return Students.FindIndex(s => s.Id == studentId);
        }

        // Find course index by ID
        public int FindCourseIndex(int courseId)
        {
            return Courses.FindIndex(c => c.CourseId == courseId);
        }



        // Find instructor index by ID
        public int FindInstructorIndex(int instructorId)
        {
           
           return Instructors.FindIndex(i => i.Id == instructorId);
        }


        public int FindStudentIndex(string studentName)
        {
            return Students.FindIndex(s => s.Name.Equals(studentName, StringComparison.OrdinalIgnoreCase));
        }

        public int FindCourseIndex(string courseTitle)
        {
            return Courses.FindIndex(c => c.Title.Equals(courseTitle, StringComparison.OrdinalIgnoreCase));
        }

        public int FindInstructorIndex(string instructorName)
        {
            return Instructors.FindIndex(i => i.Name.Equals(instructorName, StringComparison.OrdinalIgnoreCase));
        }

        // Enroll student in a course
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            int studentIndex = FindStudentIndex(studentId);
            int courseIndex = FindCourseIndex(courseId);

            if (studentIndex != -1 && courseIndex != -1)
            {
                Students[studentIndex].EnrollInCourse(Courses[courseIndex]);
                return true;
            }
            return false;
        }

        // Check if student enrolled in specific course
        public bool IsStudentEnrolledInCourse(int studentId, int courseId)
        {
            int studentIndex = FindStudentIndex(studentId);
            
            if (studentIndex != -1)
            {
                return Students[studentIndex].IsEnrolledInCourse(courseId);
            }
            return false;
        }

        // Return instructor name by course title
        public string GetInstructorNameByCourseTitle(string courseTitle)
        {
            int courseIndex = FindCourseIndex(courseTitle);
            if (courseIndex != -1 && Courses[courseIndex].AssignedInstructor != null)
            {
                return Courses[courseIndex].AssignedInstructor.Name;
            }
            return "No Instructor Assigned yet!";
        }

        // Menu
        public void Menu()
        {
            
            while (true)
            {
                Console.WriteLine("\n===== SCHOOL MENU =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find Student (by ID or Name)");
                Console.WriteLine("9. Find Course (by ID or Name)");
                Console.WriteLine("10. Check if student enrolled in specific course");
                Console.WriteLine("11. Return Instructor Name by Course Name");
                Console.WriteLine("12. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Student ID: ");
                        if (int.TryParse(Console.ReadLine(), out int sid))
                        {
                            if(FindStudentIndex(sid) != -1)
                            {
                                Console.WriteLine($"The student id: {sid} is already exist, Please enter another one!");
                            }
                            Console.Write("Enter Student Name: ");
                            string sname = Console.ReadLine();
                            Console.Write("Enter Age: ");
                            if (int.TryParse(Console.ReadLine(), out int age))
                            {
                                AddStudent(new Student(sid, sname, age));
                                Console.WriteLine("Student added successfully!");
                            }
                            else Console.WriteLine("Invalid age.");
                        }
                        else Console.WriteLine("Invalid Student ID.");
                        break;

                    case 2:
                        Console.Write("Enter Instructor ID: ");
                        if (int.TryParse(Console.ReadLine(), out int iid))
                        {
                            if (FindInstructorIndex(iid) != -1)
                            {
                                Console.WriteLine($"The instructor id: {iid} is already exist, Please enter another one!");
                            }
                            Console.Write("Enter Instructor Name: ");
                            string iname = Console.ReadLine();
                            Console.Write("Enter Specialization: ");
                            string spec = Console.ReadLine();
                            AddInstructor(new Instructor(iid, iname, spec));
                            Console.WriteLine("Instructor added successfully!");
                        }
                        else Console.WriteLine("Invalid Instructor ID.");
                        break;

                    case 3:
                        Console.Write("Enter Course ID: ");
                        if (int.TryParse(Console.ReadLine(), out int cid))
                        {
                            if (FindCourseIndex(cid) != -1)
                            {
                                Console.WriteLine($"The course id: {cid} is already exist, Please enter another one!");
                            }
                            Console.Write("Enter Course Title: ");
                            string courseTitle = Console.ReadLine();
                            Console.Write("Enter Instructor ID for this course: ");
                            if (int.TryParse(Console.ReadLine(), out int instId))
                            {
                                int iIndex = FindInstructorIndex(instId); // Fixed method name
                                if (iIndex == -1)
                                    Console.WriteLine("Instructor not found!");
                                else
                                {
                                    AddCourse(new Course(cid, courseTitle, Instructors[iIndex]));
                                    Console.WriteLine("Course added successfully!");
                                }
                            }
                            else Console.WriteLine("Invalid Instructor ID.");
                        }
                        else Console.WriteLine("Invalid Course ID.");
                        break;

                    case 4:
                        Console.Write("Enter Student ID: ");
                        if (int.TryParse(Console.ReadLine(), out sid))
                        {
                            Console.Write("Enter Course ID: ");
                            if (int.TryParse(Console.ReadLine(), out cid))
                            {
                                Console.WriteLine(EnrollStudentInCourse(sid, cid) ? "Enrolled successfully!" : "Failed to enroll.");
                            }
                            else Console.WriteLine("Invalid Course ID.");
                        }
                        else Console.WriteLine("Invalid Student ID.");
                        break;

                    case 5: ShowAllStudents(); break;
                    case 6: ShowAllCourses(); break;
                    case 7: ShowAllInstructors(); break;

                    case 8:
                        Console.Write("Search by (1) ID or (2) Name: ");
                        if (int.TryParse(Console.ReadLine(), out int opt))
                        {
                            if (opt == 1)
                            {
                                Console.Write("Enter Student ID: ");
                                if (int.TryParse(Console.ReadLine(), out sid))
                                {
                                    int index = FindStudentIndex(sid); // Fixed method name
                                    Console.WriteLine(index == -1 ? "Not found" : Students[index].ToString());
                                }
                                else Console.WriteLine("Invalid Student ID.");
                            }
                            else if (opt == 2)
                            {
                                Console.Write("Enter Student Name: ");
                                string sname = Console.ReadLine();
                                int index = FindStudentIndex(sname); // Fixed method name
                                Console.WriteLine(index == -1 ? "Not found" : Students[index].ToString());
                            }
                            else Console.WriteLine("Invalid option.");
                        }
                        else Console.WriteLine("Invalid input.");
                        break;

                    case 9:
                        Console.Write("Search by (1) ID or (2) Name: ");
                        if (int.TryParse(Console.ReadLine(), out opt))
                        {
                            if (opt == 1)
                            {
                                Console.Write("Enter Course ID: ");
                                if (int.TryParse(Console.ReadLine(), out cid))
                                {
                                    int index = FindCourseIndex(cid); 
                                    Console.WriteLine(index == -1 ? "Not found" : Courses[index].ToString());
                                }
                                else Console.WriteLine("Invalid Course ID.");
                            }
                            else if (opt == 2)
                            {
                                Console.Write("Enter Course Name: ");
                                string courseTitle = Console.ReadLine();
                                int index = FindCourseIndex(courseTitle); 
                                Console.WriteLine(index == -1 ? "Not found" : Courses[index].ToString());
                            }
                            else Console.WriteLine("Invalid option.");
                        }
                        else Console.WriteLine("Invalid input.");
                        break;

                    case 10:
                        Console.Write("Enter Student ID: ");
                        if (int.TryParse(Console.ReadLine(), out sid))
                        {
                            Console.Write("Enter Course ID: ");
                            if (int.TryParse(Console.ReadLine(), out cid))
                            {
                                Console.WriteLine(IsStudentEnrolledInCourse(sid, cid) ? "Yes, enrolled." : "Not enrolled.");
                            }
                            else Console.WriteLine("Invalid Course ID.");
                        }
                        else Console.WriteLine("Invalid Student ID.");
                        break;

                    case 11:
                        Console.Write("Enter Course Name: ");
                        string title = Console.ReadLine();
                        Console.WriteLine($"Instructor: {GetInstructorNameByCourseTitle(title)}");
                        break;

                    case 12:
                        Console.WriteLine("Goodbye!");
                        return;


                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            School school = new School();
            school.Menu();
        }
    }
}
