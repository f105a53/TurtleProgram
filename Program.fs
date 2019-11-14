open TurtleProgramFile
open System

[<EntryPoint>]
let main argv =
    let res = TurtleProgramFile.processTurtleSteps
    //printfn " %A" res
    0 // return an integer exit code
