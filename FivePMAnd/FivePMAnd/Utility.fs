namespace FivePMUtilities
open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open System.Net
open System.IO;

module Utility =

    let getRequest (url:string) = 
        let webClient = new WebClient()
        let request = webClient.DownloadString(url)
        request
        