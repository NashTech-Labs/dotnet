using System;



class Student 
{
  int RollNo;
  string Name;
  int Age;
  int Standard;


public void SetStudent(int RollNo,string Name,int Age,int Standard)
{
  this.RollNo= RollNo;
  this.Name = Name;
  this.Age = Age;
  this.Standard = Standard;
}
public void GetStudent()
{
  Console.WriteLine("Your roll no is: {0}", this.RollNo);
  Console.WriteLine("Your name is: {0}", this.Name);
  Console.WriteLine("Your age is: {0}", this.Age);
  Console.WriteLine("Your class is: {0}", this.Standard);
}
static void Main(String[] args)
{
  Console.WriteLine("Enter you roll no");
  int RollNo = int.Parse(Console.ReadLine());
  Console.WriteLine("Enter you name");
  string Name = (Console.ReadLine());
  Console.WriteLine("Enter your age");
  int Age = int.Parse(Console.ReadLine());
  Console.WriteLine("Enter you class");
  int Standard = int.Parse(Console.ReadLine());

  Student Uzair = new Student();
  Uzair.SetStudent(22,"Uzair",24,10);
  Uzair.GetStudent();
}
}