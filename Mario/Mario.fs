// FunScript version of Elm's Mario sample
// http://elm-lang.org/edit/examples/Intermediate/Mario.elm

[<ReflectedDefinition>]
module Program

open Window
    
type mario = { x:float; y:float; vx:float; vy:float; dir:string }

let jump (_,y) m = if y > 0 && m.y = 0. then  { m with vy = 5. } else m
let gravity m = if m.y > 0. then { m with vy = m.vy - 0.1 } else m
let physics m = { m with x = m.x + m.vx; y = max 0. (m.y + m.vy) }
let walk (x,_) m = 
    { m with vx = float x 
             dir = if x < 0 then "left" elif x > 0 then "right" else m.dir }

let step dir mario = mario |> physics |> walk dir |> gravity |> jump dir

let render (w,h) (mario:mario) =
    (0., 0., w, h) |> filled (rgb 174 238 238)
    (0., h-50., w, 50.) |> filled (rgb 74 163 41)
    let verb =
        if mario.y > 0. then "jump"
        elif mario.vx <> 0. then "walk"
        else "stand"
    "mario" + verb + mario.dir + ".gif" |> image 
    |> position (w/2.-16.+mario.x,  h-50.-31.-mario.y)

let main() =
   Keyboard.init()
   let w,h = dimensions()
   let mario = ref { x=0.; y=0.; vx=0.;vy=0.;dir="right" }
   let rec update () =
        mario := !mario |> step (Keyboard.arrows())
        render (w,h) !mario      
        ts.setTimeout(update, 1000. / 60.) |> ignore
   update ()
   
do FunScript.Runtime.Run(directory="Web", components=FunScript.Interop.Components.all)