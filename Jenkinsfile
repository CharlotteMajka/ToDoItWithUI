pipeline {
    agent any
    stages {
        stage("Build Web") {
            steps {
                dir("src/UI-WebStorm/ToDoIt-Frontend") {
                  
		    sh "ng build --prod"
                    sh "docker build . -t lechampdk/todoitwebstrom"
                    }
                      

                 }
        }
        stage("Build API") {
            steps {
                sh "dotnet build src/Todoit.sln"
                sh "docker build . -t lechampdk/todoit"
            }
        }
        stage("Build database") {
            steps {
				sh  "dotnet build db/ToDoIt-DB/ToDoIt-DB.sqlproj /p:NetCoreBuild=true /p:NETCoreTargetsPath=/opt/ssdt/"
				
            }
        }
        stage("Test API") {
            steps {
                echo "===== REQUIRED: Will execute unit tests of the API project ====="
            }
        }
        stage("Deliver Web") {
            steps {
                 withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: '69e5c2f8-8f3b-4461-b829-e3532bc4b156', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }
                sh "docker push lechampdk/todoitwebstrom"
            }
        }
        stage("Deliver API") {
            steps {
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: '69e5c2f8-8f3b-4461-b829-e3532bc4b156', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }
                sh "docker push lechampdk/todoit"
            }
        }
        stage("Release staging environment") {
            steps {
				sh "docker-compose pull"
				sh "docker-compose up -d application mssql-db webstrom"
				sh "sqlpackage /Action:Publish /TargetDatabaseName:TodoDb /SourceFile:db/ToDoIt-DB/bin/Debug/ToDoIt-DB.dacpac /TargetPassword:HelloW0rld /TargetUser:sa /TargetServerName:devops.setgo.dk,23000"
            }
        }
        stage("Automated acceptance test") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
}
