# EasyECS
This solution allows you to quickly understand and start using ecslite. Please familiarize yourself with the ecslite license before using it at https://github.com/Leopotam/ecslite.git.


Данное решение позволяет очень быстро понять и начать использовать ecslite. Пожалуйста, ознакомтесь с лицензией ecslite до начала использования https://github.com/Leopotam/ecslite.git.


## Functionality
You can see all available Updates systems and enable or disable them at runtime. 
GameShare is available to transfer necessary data to all systems.


Вы можете видеть все имеющиеся Updates системы и включать и выключать их в runtime. 
Также доступен GameShare для передачи необходимых данных всем системам.
 
 
 [![](https://i.ibb.co/q03dBt0/Screenshot-2.png)]()


To start ECS, it is enough to create a GameObject in the scene and add a Startup component to it. In the Startup component itself, you can add systems to the desired system group. All unnecessary code is abstracted, which improves code readability and makes it easy to track the order of system startup.


Чтобы запустить ECS - достаточно создать GameObject на сцене и добавить ему Startup компонент. В самом Startup компоненте можно добавлять системы в нужную группу систем. Весь лишний код вынесен в абстракцию, что повышает читаемость кода, что легко позволит отслеживать порядок запуска систем.
 
 
 [![](https://i.ibb.co/P5HSCks/Screenshot-3.png)]()


 Like this:


 Вот так:
 
 
 [![](https://i.ibb.co/pvFFK2z/Screenshot-4.png)]()


You can check out the example scene. Also, I added a couple of static classes that can facilitate working with ECS and improve readability (Marker, Componenter, Filter). For information on how to use ecslite, please visit the repository at the following link: https://github.com/Leopotam/ecslite.


Вы можете ознакомиться со сценой-примером. Так же, я добавил пару статических классов, которые могут облегчить работу с ECS и улучшить читаемость (Marker, Componenter, Filter). Для получения информации  о пользовании ecslite перейдите на репозиторий по ссылке https://github.com/Leopotam/ecslite.
