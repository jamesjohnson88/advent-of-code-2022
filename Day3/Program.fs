
open System.IO

///////////////
// Functions //
///////////////
let splitInTwo = fun(x:string) ->
        let mid = x.Length / 2
        let left, right = x.ToCharArray() |> Array.splitAt mid
        let pair = (new string(left), new string(right))
        pair

let findCommonChar = fun(x:string, y:string) ->
    let commonChars = x.ToCharArray() |> Array.filter(y.Contains)
    commonChars[0]

let charToNumericValue = fun(x:char) ->
    let isLowerCase = x >= 'a' && x <= 'z'
    let raw = (int x) % 32
    let value = if isLowerCase then raw else raw + 26
    value

/////////////
// Program //
/////////////
let partOneTotal = List.ofSeq(File.ReadLines("./Day3/day3_input.txt"))
                   |> List.map (fun x ->
                       splitInTwo x
                       |> findCommonChar
                       |> charToNumericValue)
                   |> List.sum
           
printfn $"%A{partOneTotal}"

let partTwoTotal = List.ofSeq(File.ReadLines("./Day3/day3_input_small.txt"))
                   List.map (fun x ->
                       groupAsThrees x// todo - new
                       |> findCommonChar // todo - overload?
                       |> charToNumericValue)
                   |> List.sum
