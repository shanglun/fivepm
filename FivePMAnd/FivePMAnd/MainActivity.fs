namespace FivePMAnd

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open System.Net
open FivePMUtilities
open Newtonsoft.Json

type Resources = FivePMAnd.Resource

type TZInfo = 
    {
        tzName:string
        localTime: string
    }

[<Activity (Label = "FivePMFinder", MainLauncher = true, Icon = "@mipmap/icon")>]
type MainActivity () =
    inherit Activity ()

    let mutable count:int = 1

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        // Set our view from the "main" layout resource
        this.SetContentView (Resources.Layout.Main)

        // Get our button from the layout resource, and attach an event to it
        let button = this.FindViewById<Button>(Resources.Id.myButton)
        let txtView = this.FindViewById<TextView>(Resources.Id.textView1);
        button.Click.Add (fun args -> 
            let webClient = new WebClient()
            let tzi = JsonConvert.DeserializeObject<TZInfo>(webClient.DownloadString("https://fivepm.azurewebsites.net/fivePM"))
            txtView.Text <- sprintf "It's (about) 5PM in the\n\n%s Timezone! \n\nSpecifically, it is %s there" tzi.tzName tzi.localTime
        )

