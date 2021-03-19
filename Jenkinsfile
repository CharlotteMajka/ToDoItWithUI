pipeline {
    agent any
    stages {
        stage("Build Web") {
            steps {
                echo "===== OPTIONAL: Will build the website (if needed) ====="
            }
        }
        stage("Build API") {
            steps {
                sh "dotnet build src/Todoit.sln"
                sh "docker build . -t lechampdk/todoit"
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerHub', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }
                sh "docker push lechampdk/todoit"
            }
        }
        stage("Build database") {
            steps {
                echo "===== OPTIONAL: Will build the database (if using a state-based approach) ====="
            }
        }
        stage("Test API") {
            steps {
                echo "===== REQUIRED: Will execute unit tests of the API project ====="
            }
        }
        stage("Deliver Web") {
            steps {
                echo "===== REQUIRED: Will deliver the website to Docker Hub ====="
            }
        }
        stage("Deliver API") {
            steps {
                echo "===== REQUIRED: Will deliver the API to Docker Hub ====="
            }
        }
        stage("Release staging environment") {
            steps {
				sh "docker-compose pull"
				sh "docker-compose up -d application msssql-db"
                sh "sqlpackage /Action:Publish /TargetPassword:HelloW0rld /TargetUser:sa /TargetServerName:devops.setgo.dk,23000"
            }
        }
        stage("Automated acceptance test") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
}