// HELPER FUNCTIONS
let add1 = fun n -> n + 1
let sqr = fun n -> n * n

// 1. process-4
let process4 = fun action -> action 4

// 2. mymap
let rec mymap = fun transform stackOfItems ->
    match stackOfItems with
    | [] -> []
    | topItem :: restOfStack -> (transform topItem) :: (mymap transform restOfStack)

// 3. second-min
let secondMin = fun numbers ->
    let uniqueNumbers = List.distinct numbers
    let rankedNumbers = List.sort uniqueNumbers
    match rankedNumbers with 
    | smallest :: second :: leftovers -> second
    | fewerThanTwoNumbers -> failwith "Need at least two unique values!"
