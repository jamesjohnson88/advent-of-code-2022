
open System.IO

///////////////
// Functions //
///////////////
let splitInTwo = fun(x:string) ->
    let mid = x.Length / 2
    let left, right = x.ToCharArray() |> Array.splitAt mid
    let pair = (new string(left), new string(right))
    pair

let groupAsThrees = fun(x:list<string>) ->
    let groups = x |> Seq.chunkBySize 3
                   |> Seq.map(fun y -> (new string(y[0]), new string(y[1]), new string(y[2])))
                   |> Seq.toList
    groups

let findCommonChar2 = fun(x:string, y:string) ->
    let commonChars = x.ToCharArray() |> Array.filter(y.Contains)
    commonChars[0]
    
let findCommonChar3 = fun(x:string, y:string, z:string) ->
    let commonChars = x.ToCharArray() |> Array.filter(y.Contains) |> Array.filter(z.Contains)
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
                       |> findCommonChar2
                       |> charToNumericValue)
                   |> List.sum
           
printfn $"%A{partOneTotal}"

let partTwoTotal = List.ofSeq(File.ReadLines("./Day3/day3_input.txt"))
                   |> groupAsThrees
                   |> List.map (fun x ->
                       findCommonChar3 x
                       |> charToNumericValue)
                   |> List.sum
                   
printfn $"%A{partTwoTotal}"