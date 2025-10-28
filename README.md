one project has one solution and one .sln file 

springbootapplication main class  =  program.cs 
application.properties  =  aaplication.json
jpa repository  :  dbcontext



 a solution  can hold multiple projects 

created an application: 

1. installed packages : dependency: manage nuget packages : installed some dpendecies

2. craeted entity classs :model folder: entity folder

3.db context :  data folder : applicationDbContext.cs  file  to set  up the db context 

4. go for appsetting.json and add the connection string 

5.  configure the  dbcontext in program.cs file 

6. create the db  and tables using package manager console  run : add-migration "intial MIgration"  : a migration folder will
    be created  consisting of system generated files ready to create db and  table   after  then run 

8. run  update database command 
