<Query Kind="Statements" />

// Title: Replicating the 'IN' operator in LINQ
// Link: http://www.devcurry.com/2009/05/replicating-in-operator-in-linq.html

var pinCodes = new[] { 411021, 411029, 411044 };

var Booths = new[]
{
    new { BoothName = "Booth1", PinCode = 411011 },
    new { BoothName = "Booth2", PinCode = 411021},
    new { BoothName = "Booth3", PinCode = 411029 },
    new { BoothName = "Booth4", PinCode = 411044 },
    new { BoothName = "Booth5", PinCode = 411056 },
    new { BoothName = "Booth6", PinCode = 411023 },
    new { BoothName = "Booth7", PinCode = 411024 }
};

 

(from booth in Booths
 join pins in pinCodes on booth.PinCode equals pins
 select booth).Dump();