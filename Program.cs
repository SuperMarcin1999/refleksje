#nullable enable
using System.Reflection;
using Refleksje;

var address = new Address()
{
    City = "Krakow",
    PostalCode = "41-222",
    Street = "Porazki 5"
};

var person = new Person()
{
    Address = address,
    FirstName = "Marcin",
    LastName = "Knapik"
};


Display(address);

Console.WriteLine();

Display(person);

Console.WriteLine("Please enter property name: ");
var propName = Console.ReadLine();

Console.WriteLine("Please enter property value: ");
var propValue = Console.ReadLine();

(address as object).SetValue(propName  ?? "", propValue); // bez T
address.SetValue<Address>(propName ?? "", propValue); // T
address.SetValue(propName ?? "", propValue); // T
Display(address);

static void Display(object obj)
{
    var objType = obj.GetType();

    var properties = objType.GetProperties();

    foreach (var property in properties)
    {
        var propValue = property.GetValue(obj);

        var propType = propValue?.GetType();

        if (propType.IsPrimitive  || propType == typeof(string))
        {
            var attribute = property.GetCustomAttribute<DisplayPropertyAttribute>();

            Console.WriteLine(attribute == null
                ? $"{property.Name} : {propValue}"
                : $"{attribute.DisplayName} : {propValue}");
        }
    }
}