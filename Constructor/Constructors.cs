using System;



class Student 
{
  int RollNo;
  string Name;
  int Age;

  public Student()
  {
    Console.WriteLine("Constructor is invoked");
  }
  public Student(int RollNo, string Name, int Age)
  {
    this.RollNo = RollNo;
    this.Name = Name;
    this.Age = Age;
  }
  public void GetStudent()
  {
  Console.WriteLine("Your roll no is: {0}", this.RollNo);
  Console.WriteLine("Your name is: {0}", this.Name);
  Console.WriteLine("Your age is: {0}", this.Age);
  }
  static void Main(String[] args)
  {
    // Student karan = new Student();
    Student Uzair = new Student(22,"Uzair",23);
    Uzair.GetStudent();
  }
}
