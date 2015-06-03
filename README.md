# ScreenConnectRestarter
A simple console application for restarting the ScreenConnect service on client machines

# About
I currently run ScreenConnect to support family members with the odd technical issue. I don't need it to be constantly accessible so the server sits virtualized on my desktop, which isn't always powered on. When I do start ScreenConnect back up, the clients can take a long time to reconnect as the reconnect timeout has increased to some unreasonably high amount of time.

So I wrote this basic console app. The idea is that you leave this on a client's desktop or whatever and have them run it if their PC isn't showing up in the Admin console. It searches for any service starting with "ScreenConnect Client" and attempts to restart it.

This executable will prompt you to elevate via UAC as it needs Administrator privileges in order to start and stop services.

# Preview
![restart_preview](https://cloud.githubusercontent.com/assets/5166470/7969668/4f680cc2-09ed-11e5-8a84-7fd852288d74.png)
