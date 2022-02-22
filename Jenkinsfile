pipeline {
    //配置执行环境
    agent {
        label 'k8s-slave-pipeline'
    }
    options {
            timeout(time: 30, unit: 'MINUTES')
            buildDiscarder(logRotator(numToKeepStr: '5', artifactNumToKeepStr: '5'))
    }
    //设置环境变量
    environment {
        IMAGE = """${sh(
                returnStdout: true,
                script: 'echo  ${NEW_ALI_REGISTRY}"/masa/masa-blazor-pro:0.0."${BUILD_ID}'
            )}"""
        IMAGE_PRD =  """${sh(
                returnStdout: true,
                script: 'echo  ${NEW_ALI_REGISTRY}"/masa/masa-blazor-pro:"${GIT_BRANCH}'
            )}"""
        NEW_ALI_REGISTRY_AUTH = credentials('NEW_ALI_REGISTRY_AUTH')
        KUBE_CONFIG = credentials('k8s-ack')
    }
    //执行阶段
    stages {
        stage('setting env') {
            agent {
                label 'dotnet6'
            }
            options {
                skipDefaultCheckout(true)
            }
            steps {
                wrap([$class: 'BuildUser']) {
                    script {
                        BUILD_USER = "${BUILD_USER}"
                        BUILD_USER_ID ="${BUILD_USER_ID}"
                    }
                    script {
                        env.BUILD_USERNAME = "${BUILD_USER}"
                        env.BUILD_USERNAMEID = "${BUILD_USER_ID}"
                    }
                }
            }
        }   
        //构建docker镜像
        stage('docker') {
            options {
                retry (2)
            }
            when {
                branch 'develop'
            }
            steps {
                container('docker') {
                    sh '''
                          docker login $NEW_ALI_REGISTRY --username=$NEW_ALI_REGISTRY_AUTH_USR -p $NEW_ALI_REGISTRY_AUTH_PSW                     
                          docker build --force-rm  -f ./MASA.Blazor.Pro/Dockerfile -t $IMAGE .                     
                          docker push $IMAGE
                          docker rmi $IMAGE 
                       '''
                }
            }
            
        }
        //发布开发环境
        stage('deploy-dev') {
            when {
                branch 'develop'
            }
            steps {
                container('kubectl') {
                    sh '''
                          kubectl set image deployment/masa-blazor-pro masa-blazor-pro=$IMAGE -n masa-blazor
                       '''
                }
            }
        }
        //发布测试环境
        stage('deploy-test') {
            when {
                branch 'develop'
            }
            steps {
                container('kubectl') {
                    sh '''
                          kubectl set image deployment/masa-blazor-pro masa-blazor-pro=$IMAGE -n masa-blazor
                       '''
                }
            }
        }
    }
    post {
        success {
           script {
               sh 'export TYPE=success;export JOB_NAME="${JOB_BASE_NAME}";export BUILD_NUM="$BUILD_NUMBER";export BUILD_TIME="$BUILD_TIMESTAMP";export BUILD_USER="${BUILD_USERNAME}"; export URL_JOB="${BUILD_URL}";export URL_LOG="${BUILD_URL}console";export JOB_TIPS1="${BUILD_USERNAMEID}" ;sh send_message-export.sh'
           }
        }
        failure {
            script {
                sh 'export TYPE=failure;export JOB_NAME="${JOB_BASE_NAME}";export BUILD_NUM="$BUILD_NUMBER";export BUILD_TIME="$BUILD_TIMESTAMP"; export BUILD_USER="${BUILD_USERNAME}"; export URL_JOB="${BUILD_URL}";export URL_LOG="${BUILD_URL}console";export JOB_TIPS1="${BUILD_USERNAMEID}" ;sh send_message-export.sh'
            }
        }
    }
}

   
