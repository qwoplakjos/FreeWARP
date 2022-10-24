# Free WARP+

First version of WARP+ GB adder that supports http, socks4 and socks5 proxies at the same time!

With checked proxies and 100 threads I was able to reach speed of about 10 gb / 3 seconds. But got banned shortly after that.

I would recommend running it with about 50-70 threads.

It also doesn't stop after running out of proxies. It will start over when it gets to the end.

Proxies are loaded through a file with a new proxy on each line like this: 
```
1.2.3.4:80
5.6.7.8:8080
11.22.33.44:3128
```

`P.S. Code is pretty messy overall. Feel free to improve it.`


### Screenshot of GUI

![image](https://user-images.githubusercontent.com/60236726/197609514-1a71895e-fbc8-4f32-8f73-aa7dbeeb3ed7.png)
