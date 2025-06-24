pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git credentialsId: 'github-creds', url: 'https://github.com/divyeshx07/for-todo.git', branch: 'main'
            }
        }

        stage('Build') {
            steps {
                dir('package.json') {
                  bat 'npm install'
                  bat 'npm run build'
              }
          }
      }


        stage('Deploy to EC2') {
            steps {
                sshagent(['ec2-ssh-key']) {
                    bat 'scp -o StrictHostKeyChecking=no -r ./build ubuntu@<35.176.246.99>:/home/ubuntu/todoapp'
                    bat 'ssh -o StrictHostKeyChecking=no ubuntu@<35.176.246.99> "cd /home/ubuntu/todoapp && npm install && npm start"'
                }
            }
        }
    }
}
