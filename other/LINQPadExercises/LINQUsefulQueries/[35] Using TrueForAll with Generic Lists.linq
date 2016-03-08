<Query Kind="Statements" />

// Title: Using TrueForAll with Generic Lists
// Link: http://www.devcurry.com/2009/12/using-trueforall-with-generic-lists.html

var numbers = new List<int>() { 4, 6, 7, 8, 34, 33, 11};

bool isTrue = true;

foreach (var i in numbers)
{
  if (i <= 0)
  {
    isTrue = false;
  }
}

isTrue.Dump();

numbers.TrueForAll(o => o > 0).Dump();