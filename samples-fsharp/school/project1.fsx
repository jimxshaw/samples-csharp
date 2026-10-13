// HELPER FUNCTIONS
let add1 = fun n -> n + 1
let sqr = fun n -> n * n

// 1. process-4: hands 4 to the given function.
let process4 = fun action -> action 4

// 2. mymap: empty list -> empty list. Otherwise transform the first item,
// then let mymap handle the rest and put the two back together.
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


