<Query Kind="Statements" />

// Title: How to Sort Data using LINQ
// Link: http://www.devcurry.com/2009/08/how-to-sort-data-using-linq.html

ArrayList names = new ArrayList(5);

names.Add("Tony Abbot");
names.Add("Tony A Farrow");
names.Add("Tony Charles");
names.Add("Tony Small");
names.Add("Bob Brown");

var query = from p in names.Cast<string>()
            let count = p.Split(' ').Length - 1
            let surname = p.Split(' ')[count]
            let givenname = p.Split(' ')[0]
            orderby surname ascending
            select new
            {
                GivenName = givenname,
                Surname = surname
            };

query.Dump();