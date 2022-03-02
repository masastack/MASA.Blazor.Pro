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
        KUBE_CONFIG_PRD = credentials('k8s-ack-prd')
    }
    //执行阶段
    stages {   
        //构建docker镜像
        stage('docker-dev') {
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
                          docker build --force-rm  -f ./Masa.Blazor.Pro/Dockerfile -t $IMAGE .                     
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
                          echo $KUBE_CONFIG_DEV | base64 --decode >> ./config
                          kubectl --kubeconfig ./config set image deployment/masa-blazor-pro masa-blazor-pro=$IMAGE -n masa-blazor
                       '''
                }
            }
        }
        stage('docker-prd') {
            options {
                retry (2)
            }
            when {
                buildingTag()
            }
            steps {
                container('docker') {
                    sh '''
                          docker login $NEW_ALI_REGISTRY --username=$NEW_ALI_REGISTRY_AUTH_USR -p $NEW_ALI_REGISTRY_AUTH_PSW                     
                          docker build --force-rm  -f ./Masa.Blazor.Pro/Dockerfile -t $IMAGE_PRD .                     
                          docker push $IMAGE_PRD
                          docker rmi $IMAGE_PRD
                       '''
                }
            }
            
        }
        stage('deploy-prd') {
            when {
                buildingTag()
            }
            steps {
                container('kubectl') {
                    sh '''
                          echo $KUBE_CONFIG_PRD | base64 --decode >> ./config
                          kubectl --kubeconfig ./config set image deployment/masa-blazor-pro masa-blazor-pro=$IMAGE -n masa-blazor
                       '''
                }
            }
        }
    }
}
   
