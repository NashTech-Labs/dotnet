using System;

class Student {

	public int RollNo;
	public string Name;

	public Student(int r, string n)
	{
		RollNo = r;
		Name = n;
	}

	
	public int getRollNo()
	{
		return RollNo;
	}
	public string getName()
	{
		return Name;
	}
}

class Program {

	static void Main(string[] args)
	{
		Student S = new Student(1, "Uzair");

		Console.WriteLine("Roll number: {0}", S.RollNo);
		Console.WriteLine("Name: {0}", S.Name);

		Console.WriteLine();

		Console.WriteLine("Roll number: {0}", S.getRollNo());
		Console.WriteLine("Name: {0}", S.getName());
	}
}


