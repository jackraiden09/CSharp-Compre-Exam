namespace SalesSystem.Models 
{
    public class Person {
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}

        public Person(int id, string fName, string lName)
        {
            this.Id = id;
            this.FirstName = fName;
            this.LastName = lName;
        }
    }
}