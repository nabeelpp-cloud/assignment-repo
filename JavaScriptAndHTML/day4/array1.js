console.log("Student")
const student = [
    {
      FirstName: "John",
      LastName: "Doe",
      Age: 20,
      Department: "Computer Science",
    },
    {
      FirstName: "Jane",
      LastName: "Smith",
      Age: 22,
      Department: "Physics",
    },
    {
      FirstName: "Michael",
      LastName: "Johnson",
      Age: 21,
      Department: "Mathematics",
    },
    {
      FirstName: "Sarah",
      LastName: "Williams",
      Age: 19,
      Department: "Computer Science",
    },
    {
      FirstName: "Robert",
      LastName: "Brown",
      Age: 23,
      Department: "Mathematics",
    },
    {
      FirstName: "Emily",
      LastName: "Davis",
      Age: 20,
      Department: "Computer Science",
    },
  ];

  const computerScinceStidents = student.filter(
    (x) => x.Department === "Computer Science"
  );
  console.log("Computer science students : ");
  for (let i = 0; i < computerScinceStidents.length; i++) {
    console.log(computerScinceStidents[i]);
  }
  const ageGreater21 = student.filter((x) => x.Age > 21);
  console.log(
    "Age greater that 21 : " + ageGreater21.map((x) => x.FirstName)
  );
  const bool = student.some(
    (x) => x.Department === "Mathematics" && x.Age > 23
  );
  console.log(
    "Is any student with age above 23 and in mathematics department : " +
      bool
  );

  const checkAbove18 = student.every((x) => x.Age > 18);
  console.log("Is all students are above 18 : " + checkAbove18);

  const studentWithFirstNameJohn = student.find(
    (x) => x.FirstName === "John"
  );
  console.log(
    "Department of John : " + studentWithFirstNameJohn.Department
  );

  