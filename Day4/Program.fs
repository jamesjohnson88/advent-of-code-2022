
open System.IO

///////////////
// Functions //
///////////////

let compareAssignments = fun(x:string) ->
    "hello"

/////////////
// Program //
/////////////
let partOnePairs = List.ofSeq(File.ReadLines("./Day4/day4_input_small.txt"))
                   |> List.map (fun x -> x |> compareAssignments)
           
printfn $"%A{partOnePairs}"