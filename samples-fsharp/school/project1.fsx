// HELPER FUNCTIONS
let add1 = fun n -> n + 1
let sqr = fun n -> n * n

// 1. process-4: must be named process4 because F# thinks 
// process-4 means process minus 4.
let process4 = fun action -> action 4

// 2. mymap: keyword rec means the function is allowed to call itself.
// Take 2 inputs, an action (transform) and a stack of items, and look
// at the stack and decide which case it is. 
// Case 1 is the stack is empty. Return this.
// Case 2 is the stack has something on it. Call the topItem and
// the remaining restOfStack. Call the transform function on the 
// topItem and then call mymap on the restOfStack. 
// Return a new stack with the transformed topItem and 
// the transformed restOfStack.
// The bar | symbol is like a case in a C# switch statement.
// The double :: colon symbol means either take a stack apart or
// builds a stack back together depending on which side of 
// the symbol it is on.
let rec mymap = fun transform stackOfItems ->
    match stackOfItems with
    | [] -> []
    | topItem :: restOfStack -> (transform topItem) :: (mymap transform restOfStack)


