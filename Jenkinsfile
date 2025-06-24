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
                bat 'scp -i C:\\Users\\pd550\\Downloads\\ssh-todo-key.pem -o StrictHostKeyChecking=no -r published/* ubuntu@35.176.246.99:/home/ubuntu/todoapp'
                bat 'ssh -i C:\\Users\\pd550\\Downloads\\ssh-todo-key.pem -o StrictHostKeyChecking=no ubuntu@35.176.246.99 "cd /home/ubuntu/todoapp && nohup dotnet TodoApi.dll > log.txt 2>&1 &"'
            }
        }
    }
}
