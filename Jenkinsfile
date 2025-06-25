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
                bat 'dir C:\\JenkinsKeys'
                bat 'scp -i C:\\JenkinsKeys\\ssh-todo-key.pem -o StrictHostKeyChecking=no -r published/* ubuntu@35.176.246.99:/home/ubuntu/todoapp'
                bat 'ssh -i C:\\JenkinsKeys\\ssh-todo-key.pem -o StrictHostKeyChecking=no ubuntu@35.176.246.99 "cd /home/ubuntu/todoapp && nohup dotnet TodoApi.dll > log.txt 2>&1 &"'
            }
        }
    }
}
