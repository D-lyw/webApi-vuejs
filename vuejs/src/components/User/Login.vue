<template>
    <div id="main">
        <h2>- <span>在线投票系统</span> -</h2>
        <div class="demo-input-suffix">
            <label for="u">用户名：</label>
            <el-input
                id="u"
                placeholder="请输入用户名"
                prefix-icon = 'el-icon-service'
                v-model="username"
                width="60%">
            </el-input>

           
        </div>
        <div class="demo-input-suffix">
            <label for="p">密码:</label>
            <el-input
                id="p"
                placeholder="请输入密码"
                prefix-icon="el-icon-info"
                v-model="password"
                type="password">
            </el-input>
        </div>
        <br>
        <el-row>
            <el-button  type="success" round size="small" @click="UserLogin">Login</el-button>
            <el-button plain round size="small" @click="JumpToRegister">Register</el-button>
        </el-row>
    </div>
</template>

<script>
export default {
    name: 'login',
    data () {
        return {
            username: '',
            password: ''
        }
    },
    methods: {
        UserLogin(){
            var data = {
                username: this.username,
                password: this.password
            }
            // 判断用户名和密码
            this.axios.post(this.url + '/Login', data)
                .then((data) => {
                    console.log(data.data);
                    if (data.data == 1) {
                        // 登陆成功
                        // this.prototype.uname = this.username;
                        this.$router.push('/home/Index')
                    } else {
                        // 登陆错误
                        this.$message.error('账号或密码错误！');
                    }
                }).catch((err) => {
                        this.$message.error('程序出错');
                        this.$router.push('/home/Index')
                })
            
            
        },
        JumpToRegister(){
            this.$router.push('/register');
        }
    },
}
</script>

<style scoped>
#main{
    width: 300px;
    top: 100px;
    padding: 30px 5%;
    margin: auto;
    border-radius: 6px;
    /* border: 1px solid grey; */
    box-shadow: 0 2px 4px rgba(0, 0, 0, .12), 0 0 6px rgba(0, 0, 0, .04)
}
span{
    color: orangered;
}
label{
    text-align: left;
    padding: 3px;
    margin: 10px 0 3px;
    float: left;
}
</style>
