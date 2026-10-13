// HELPER FUNCTIONS
let add1 = fun n -> n + 1
let sqr = fun n -> n * n

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
