# BlazorApp
Projeto interdisciplinar da faculdade em que é utilizado Blazor para front-end conectado a uma API para back-end

# Comandos GIT

## Criar branch local e conectar com a branch remota

1- Primeiro, certifique-se de que você já tenha clonado o repositório remoto para o seu computador local usando o comando git clone.\
2- Crie uma nova branch local com o nome desejado usando o comando:\
&emsp;`git branch nome-da-branch`

3 - Mude para a nova branch que você criou usando o comando:\
&emsp;``git checkout nome-da-branch``

4 - Agora, faça o push da sua nova branch local para o repositório remoto usando o comando:\
&emsp;```git push -u origin nome-da-branch```
O parâmetro -u (ou --set-upstream) estabelecerá a conexão entre a sua branch local e a branch remota no repositório. A partir de agora, quando você fizer git push ou git pull, o Git saberá qual branch remota está vinculada à sua branch local.