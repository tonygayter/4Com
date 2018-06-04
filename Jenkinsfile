pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        sh 'ping -c 1 127.0.0.1'
      }
    }
    stage('Test') {
      steps {
        sh 'ping -c 1 127.0.0.1'
      }
    }
    stage('Deploy') {
      steps {
        sh 'ping -c 2 127.0.0.1'
      }
    }
  }
}