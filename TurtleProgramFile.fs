module TurtleProgramFile


[<Measure>]
type Degrees

/// An alias for a float of Degrees
type Angle = float<Degrees>

type State =
    { x: float
      y: float
      heading: Angle
      pen: bool }

type Command =
    | Forward of float
    | ChangeAngle of Angle
    | SetPen of bool

let calcNewPosition (distance: float) (angle: Angle) x y =
    // Convert degrees to radians with 180.0 degrees = 1 pi radian
    let angleInRads = angle * (System.Math.PI / 180.0<Degrees>)
    // current pos
    let x0 = x
    let y0 = y
    // new pos
    let x1 = x0 + (distance * cos angleInRads)
    let y1 = y0 + (distance * sin angleInRads)
    // return a new Position
    (x1, y1)

let processState oldState command =
    match command with
    | Forward amount ->
        let x, y = calcNewPosition amount oldState.heading oldState.x oldState.y
        { oldState with
              x = x
              y = y }
    | ChangeAngle angle -> { oldState with heading = angle }
    | SetPen isDrawing -> { oldState with pen = isDrawing }

let LogState(state: State) =
    printfn "%A" state
    state

let processTurtleSteps =
    List.fold (fun state item ->
        let newState = processState state item
        LogState newState)
        { x = 0.0
          y = 0.0
          heading = 0.0<Degrees>
          pen = false }
        [ Forward 1.0
          SetPen true
          ChangeAngle 45.0<Degrees>
          Forward 1.0 ]
]