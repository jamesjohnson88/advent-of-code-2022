﻿
open System.IO

let stringsEnumerable = File.ReadLines("./Day3/day3_input_small.txt")

let line = "vJrwpWtwJgWrhcsFMMfFFhFp"

let splitInTwo = fun(x:string) ->
    let mid = x.Length / 2
    let (left, right) = x.ToCharArray() |> Array.splitAt mid
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

splitInTwo line
|> findCommonChar
|> charToNumericValue
|> printfn "%d"
