<template>
    <div id="main">
        <h2>- <span>用户注册</span> -</h2>
        <div class="demo-input-suffix">
            <label for="u">用户名：</label>
            <el-input
                id="u"
                placeholder="请输入用户名"
                suffix-icon = 'el-icon-edit'
                v-model="username"
                width="60%">
            </el-input>

        </div>
        <div class="demo-input-suffix">
            <label for="p">密码:</label>
            <el-input
                id="p"
                placeholder="请输入密码"
                suffix-icon="el-icon-edit"
                v-model="password"
                type="password">
            </el-input>
        </div>
        <br>
        <el-row>
            <el-button  type="success" round size="small" @click="UserRegister">Register</el-button>
            <el-button plain round size="small" @click="GoToLogin"> go to login</el-button>
        </el-row>
    </div>
</template>

<script>
export default {
    name: 'register',
    data () {
        return {
            username: '',
            password: ''
        }
    },
    methods: {
        GoToLogin(){
            this.$router.push('/login');
        },
        UserRegister(){
            var data = {
                username: this.username,
                password: this.password
            }
            this.axios.post(this.url + '/register', data)
                .then((data) => {
                    console.log(data);
                    if(data.data == 1) {
                        this.$message({
                            message: '用户注册成功！',
                            type: 'success'
                        });
                    } else {
                        this.$message({
                            message: '用户注册失败！',
                            type: 'warning'
                        });
                    }
                })
                .catch((err) => {
                        this.$message({
                            message: '程序出错',
                            type: 'error'
                        })
                })
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
