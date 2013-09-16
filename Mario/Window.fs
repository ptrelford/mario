[<ReflectedDefinition>]
module Window

let canvas () = unbox<ts.HTMLCanvasElement>(ts.document.getElementById("canvas"))
let context () = canvas().getContext("2d")

let ($) s n = s + n.ToString()
let rgb r g b = "rgb(" $ r $ "," $ g $ "," $ b $ ")"

let filled color rect =
    let ctx = context()
    ctx.fillStyle <- color
    ctx.fillRect rect    

let position (x,y) img =
    let img = unbox<ts.HTMLElement>(img)
    img.style.posLeft <- x
    img.style.posTop <- canvas().AsHTMLElement().offsetTop + y

let dimensions () = canvas().width, canvas().height

let image (src:string) = 
    let image = unbox<ts.HTMLImageElement>(ts.document.getElementById("image"))
    if image.src.IndexOf(src) = -1 then image.src <- src
    image

