[<ReflectedDefinition>]
module Keyboard

let mutable keysPressed = Set.empty
let code x = if keysPressed.Contains(x) then 1 else 0
let arrows () = (code 39 - code 37, code 38 - code 40)
let update (e,pressed) =
    let e = (unbox<ts.KeyboardEventExtensions>(e))
    let keyCode = int e.keyCode
    let op =  if pressed then Set.add else Set.remove
    keysPressed <- op keyCode keysPressed
let init () =
    ts.addEventListener("keydown", unbox<ts.EventListener>(fun e -> update(e, true)))
    ts.addEventListener("keyup", unbox<ts.EventListener>(fun e -> update(e,false)))    

