pipeline {
    agent any

    tools {
        dotnet 'dotnet-9' // Make sure this matches the label under "Global Tool Configuration"
    }

    stages {
        stage('Checkout') {
            steps {
                git credentialsId: 'github-creds', url: 'https://github.com/divyeshx07/for-todo.git', branch: 'main'
            }
        }

        stage('Build & Publish') {
            steps {
                bat 'dotnet restore ToDoApp.sln'
                bat 'dotnet build TodoApi/TodoApi.csproj --configuration Release'
                bat 'dotnet publish TodoApi/TodoApi.csproj --configuration Release --output published'
            }
        }

        stage('Deploy to EC2') {
            steps {
                sshagent(['ec2-ssh-key']) {
                    bat 'scp -o StrictHostKeyChecking=no -r published/* ubuntu@<35.176.246.99>:/home/ubuntu/todoapp'
                    bat 'ssh -o StrictHostKeyChecking=no ubuntu@<35.176.246.99> "cd /home/ubuntu/todoapp && nohup dotnet TodoApi.dll > log.txt 2>&1 &"'
                }
            }
        }
    }
}
