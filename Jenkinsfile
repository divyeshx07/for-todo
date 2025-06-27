pipeline {
    agent any

    stages {
        stage('Build & Publish') {
            steps {
                bat 'dotnet restore ToDoApp.sln'
                bat 'dotnet build TodoApi/TodoApi.csproj --configuration Release'
                bat 'dotnet publish TodoApi/TodoApi.csproj --configuration Release --output published'
            }
        }

        stage('Deploy to EC2') {
            steps {
                bat 'scp -i C:\\JenkinsKeys\\Todo-key.pem -o StrictHostKeyChecking=no -r published/* ubuntu@3.111.188.80:/home/ubuntu/todoapp'
                bat 'ssh -i C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\Todo-key.pem -o StrictHostKeyChecking=no ubuntu@3.111.188.80 "cd /home/ubuntu/todoapp && nohup dotnet TodoApi.dll > log.txt 2>&1 &"'
            }
        }
    }
}
