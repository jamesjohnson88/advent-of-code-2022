
open System
open System.IO

///////////
// Types //
///////////
type Assignment (lowerValue:string, upperValue:string) =
    member this.LowerValue = Convert.ToInt16(lowerValue)
    member this.UpperValue = Convert.ToInt16(upperValue)

///////////////
// Functions //
///////////////
let parseAsAssignment = fun(x:string) ->
    Assignment("2", "5") //todo
    
let compareAssignments = fun(x:string) ->
    let split = x.Split(',')
    let assignment1 = parseAsAssignment split[0]
    let assignment2 = parseAsAssignment split[1]
    true


/////////////
// Program //
/////////////
let partOnePairs = List.ofSeq(File.ReadLines("./Day4/day4_input_small.txt"))
                   |> List.map (fun x -> x |> compareAssignments)
           
printfn $"%A{partOnePairs}"