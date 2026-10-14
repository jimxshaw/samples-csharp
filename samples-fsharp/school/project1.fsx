// HELPER FUNCTIONS
let add1 = fun n -> n + 1
let sqr = fun n -> n * n
let isEven = fun n -> n % 2 = 0

// 1. process-4: hands 4 to the given function.
let process4 = fun action -> action 4

// 2. mymap: empty list -> empty list. Otherwise transform the first item,
// then let mymap handle the rest and put the two back together.
// Must use recursion.
let rec mymap = fun transform stackOfItems ->
    match stackOfItems with
    | [] -> []
    | topItem :: restOfStack -> (transform topItem) :: (mymap transform restOfStack)

// 3. second-min: drop repeats, sort smallest to biggest, return the 2nd.
// Fewer than two unique values -> raise an error.
let secondMin = fun numbers ->
    let uniqueNumbers = List.distinct numbers
    let rankedNumbers = List.sort uniqueNumbers
    match rankedNumbers with 
    | smallest :: second :: leftovers -> second
    | fewerThanTwoNumbers -> failwith "Need at least two unique values!"

// 4. zipper: pair up items from two lists by position.
// If both lists have a top item, pair them and zip the rests.
// If either list is empty, stop (extras are ignored).
// Must use recursion.
let rec zipper = fun firstStack secondStack ->
    match (firstStack, secondStack) with 
    | (topOfFirst :: restOfFirst, topOfSecond :: restOfSecond) -> (topOfFirst, topOfSecond) :: (zipper restOfFirst restOfSecond) 
    | (leftoverFirst, leftoverSecond) -> []

// 5. classify: split a list into [passing; failing] using a yes/no test.
// A recursive helper sorts each item into one of two stacks, keeping order,
// and returns them as a pair, classify wraps that pair as a 2-item list.
// Must use recursion.
let classify = fun test stackOfItems ->
    let rec sortIntoTwoStacks = fun stack ->
        match stack with
        | [] -> ([], [])
        | topItem :: restOfStack ->
            let (passingRest, failingRest) = sortIntoTwoStacks restOfStack
            if test topItem then (topItem :: passingRest, failingRest) 
            else (passingRest, topItem :: failingRest)
    let (passing, failing) = sortIntoTwoStacks stackOfItems
    [passing; failing]

// 6. member-n-times?: is `target` in the list exactly `howMany` times?
// Recursive helper counts matches (empty list -> 0, add 1 per match) so
// the result is then compared to howMany.
let memberNTimes = fun target howMany stackOfItems ->
    let rec countMatches = fun stack ->
        match stack with
        | [] -> 0
        | topItem :: restOfStack ->
            if topItem = target then 1 + countMatches restOfStack else countMatches restOfStack
    countMatches stackOfItems = howMany
