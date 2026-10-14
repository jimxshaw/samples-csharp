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

// 7. luhn: is `number` a valid Luhn (checksum) number?
// Walk the digits right to left, doubling every 2nd digit (a doubled
// 2-digit result has its digits added). Valid if the total ends in 0.
// Uses int64 (suffix L) since card-length numbers overflow int.
// Helpers are functions only; no scratch `let` values (spec ban).
let luhn = fun number ->
    let digitValue = fun digit shouldDouble ->
        if shouldDouble then (2L * digit) / 10L + (2L * digit) % 10L else digit
    let rec sumDigits = fun remaining shouldDouble ->
        if remaining = 0L then 0L
        else digitValue (remaining % 10L) shouldDouble + sumDigits (remaining / 10L) (not shouldDouble)
    sumDigits number false % 10L = 0L

// 8. my-sorted?: is the list in order according to `isInOrder`?
// Check each neighboring pair; one failing pair makes the answer false.
// Fewer than two items has no pairs, so it counts as sorted.
// Named mySorted because F# names can't contain - or ?.
let rec mySorted = fun isInOrder stackOfItems ->
    match stackOfItems with
    | first :: second :: restOfStack -> (isInOrder first second) && mySorted isInOrder (second :: restOfStack)
    | fewerThanTwoItems -> true

// 9. my-flatten: turn arbitrarily nested lists into one flat list.
// F# lists can't nest freely so the input uses a Nested type: a single Item
// or a Group (a list of more Nested things).
// Empty -> []. Item -> keep it. Group -> flatten inside, flatten the
// rest, then glue the two results together with @.
// Named myFlatten because F# names can't contain hyphens.
// Must use recursion.
type Nested =
    | Item of int
    | Group of Nested list

let rec myFlatten = fun stackOfThings ->
    match stackOfThings with
    | [] -> []
    | (Item value) :: restOfStack -> value :: myFlatten restOfStack
    | (Group innerStack) :: restOfStack -> myFlatten innerStack @ myFlatten restOfStack

// 10. my-list-ref: return the item at position `position` (first is 0).
// Empty list -> error. Position 0 -> the top item. Otherwise ask for
// position - 1 in the rest of the list.
// Named myListRef because F# names can't contain hyphens.
let rec myListRef = fun stackOfItems position ->
    match stackOfItems with
    | [] -> failwith "ERROR: Index out of bounds"
    | topItem :: restOfStack ->
        if position = 0 then topItem else myListRef restOfStack (position - 1)
