<template>
  <div v-html="html" class="breakdownMessage">
  </div>
</template>

<script>
export default {
  data () {
    return {
      html: String
    }
  },
  props: {
    json: {}
  },
  created () {
    this.html = ''
    Object.keys(this.json).forEach((key) => {
      this.html += '<div>'
      this.html += '<h4>'
      this.html += key
      this.html += '</h4>'
      this.html += '</div>'
      if (this.json[key] === '') {
        this.html += '<h7>Empty</h7>'
      } else {
        this.html += '<div>'
        this.html += this.json[key]
        this.html += '</div>'
      }
    })
  }
}
</script>
<style>
.breakdownMessage{
  display: inline-block;
  vertical-align: top;
  width: 230px;
  margin: 20px;
  padding: 20px;
  box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22);
}
h7{
    color: grey;
}
</style>
