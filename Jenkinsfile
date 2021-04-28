pipeline {
    agent any
    stages {
        stage("Build Web") {
            steps {
                dir("src/UI-WebStorm/ToDoIt-Frontend") {
                    sh "npm install"
		    sh "ng build"
                    }
                      

                 }
        }
        stage("Build API") {
            steps {
                sh "dotnet build src/Todoit.sln"      
            }
        }
        stage("Test API") {
            steps {
                 sh "dotnet test test/UnitTest/UnitTest.csproj"
            }
        }

        stage("Automated acceptance test") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
}
